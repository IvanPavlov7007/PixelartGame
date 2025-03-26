using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBandWidthRepresentation : SideRepresentation
{
    [SerializeField]
    Renderer rend;

    float initY;
    
    
    Renderer getRenderer()
    {
        if (rend == null)
            rend = GetComponentInChildren<Renderer>();
        if (rend == null)
            throw new UnityException("Side representation has no sprites");
        return rend;
    }
    private void Start()
    {
        initY = transform.localPosition.y;

    }
    public override void Draw(float bandPosition)
    {
        //translating into camera coordinates
        var delta = parallaxPosition(bandPosition);

        if (Mathf.Abs(delta) <= xBoundary)
        {
            var sideY = SideSorting.Instance.calculateCompressedBandPosition(bandObject.bandWidthPosition);
            setWorldPos(delta, sideY);
            handleSorting(bandObject.bandWidthPosition);
        }
        else
        {
            //hide
            setWorldPos(2 * xBoundary, 0f);
        }
    }

    protected virtual void handleSorting(float bandWidthPosition)
    {
        getRenderer().sortingOrder = SideSorting.Instance.sortingOrderForPostion(bandWidthPosition);
    }

    
}
