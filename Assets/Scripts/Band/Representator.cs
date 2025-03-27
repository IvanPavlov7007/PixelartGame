using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Representator : MonoBehaviour
{
    public float currentBandPosition = 0f;

    public RepresentationType targetType;

    public Dictionary<BandObject, Representation> representations = new Dictionary<BandObject, Representation>();

    public virtual void DrawScene()
    {
        foreach (var representation in representations.Values)
        {
            representation.Draw(currentBandPosition);
        }
    }

    private void typeNotDefined(RepresentationType type)
    {
        Debug.LogError("Used type is not implemented: " + type.ToString());
    }

    public void findExistingRepresentationsInScene()
    {
        IEnumerable<Representation> components;
        switch(targetType)
        {
            case RepresentationType.Side:
                components = FindObjectsOfType<SideRepresentation>();
                break;
            case RepresentationType.Top:
                components = FindObjectsOfType<TopRepresentation>();
                break;
            default:
                typeNotDefined(targetType);
                return;
        }

        foreach (var repr in components)
        {
            repr.transform.parent = transform;
            representations.Add(repr.bandObject, repr);
        }
    }

    //TODO maybe abstract factory as additional parameter, e g with a behavior to pick a random from multiple and so on
    public virtual void addRepresentedObject(BandObject bandObject)
    {
        if (representations.ContainsKey(bandObject))
        {
            Debug.LogWarning("Band Object's representation is already created");
            return;
        }

        var holder = bandObject.GetComponent<RepresentationsHolder>();
        if (holder == null)
            throw new UnityException(name + ": " + bandObject.ToString() + " has no defined representation recipes");

        var recipe = holder.representationRecipes.Find(x => x.type == targetType);
        if (recipe == null)
            return;

        try
        {
            var representation = createRepresentation(recipe.prefab, bandObject);
            representations.Add(bandObject, representation);
        }
        catch (UnityException ex)
        {
            Debug.LogError(ex);
        }
        UnityEditor.EditorUtility.SetDirty(this);
    }

    private Representation createRepresentation(GameObject representationPrefab, BandObject bandObject)
    {
        var obj = Instantiate(representationPrefab, transform);
        Representation representation;
        switch (targetType)
        {
            case RepresentationType.Side:
                representation = FindObjectOfType<SideRepresentation>();
                break;
            case RepresentationType.Top:
                representation = FindObjectOfType<TopRepresentation>();
                break;
            default:
                typeNotDefined(targetType);
                Destroy(obj);
                return null;
        }
        representation.bandObject = bandObject;
        initializeRepresentationComponents(representation.gameObject, bandObject);
        return representation;
    }

    private void initializeRepresentationComponents(GameObject representation, BandObject bandObject)
    {
        var components = representation.GetComponentsInChildren<RepresentationComponent>();
        foreach(var c in components)
        {
            c.RepresentationInitialize(bandObject);
        }
    }
    public virtual void onBandObjectDestroy(BandObject bandObject)
    {
        Representation representation;
        if (representations.TryGetValue(bandObject, out representation))
        {
            representations.Remove(bandObject);
            Destroy(representation.gameObject);
        }
    }

}
