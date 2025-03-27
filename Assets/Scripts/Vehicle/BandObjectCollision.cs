using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandObjectCollision : MonoBehaviour
{
    [SerializeField]
    BoxCollider collider;
    public virtual void CheckCollisions()
    {
        var overlaps = Physics.OverlapBox(collider.center + transform.position, collider.size * 0.5f);
        foreach(var col in overlaps)
        {
            if (collider != col)
            {
                hit(collider);
            }
        }
    }

    protected virtual void hit(Collider col)
    {
        col.SendMessage("ReceiveHit", col);
        //Debug.Log(collider.name + " overlaps with " + col.name);
    }
}
