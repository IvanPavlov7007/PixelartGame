using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum RepresentationType
{
    Side, Top
}

[Serializable]
public class RepresentationRecipe
{
    public RepresentationType type;
    public GameObject prefab;
}

public class RepresentationsHolder : MonoBehaviour
{
    public List<RepresentationRecipe> representationRecipes;

    public BandObject bandObject { get { return GetComponent<BandObject>(); } }

    [ContextMenu("Add this band object to representators")]
    public void showInRepresentators()
    {
        foreach(var recipe in representationRecipes)
        {
            switch (recipe.type)
            {
                case RepresentationType.Side:
                    var representatorSide = FindObjectOfType<RepresentatorSide>();
                    if(representatorSide != null)
                        representatorSide.addRepresentedObject(bandObject);
                    break;
                case RepresentationType.Top:
                    var representatorTop = FindObjectOfType<RepresentatorTop>();
                    if (representatorTop != null)
                        representatorTop.addRepresentedObject(bandObject);
                    break;
                default:
                    Debug.LogError(name + " tries to create a not implemented representation");
                    break;
            }
        }
    }
}
