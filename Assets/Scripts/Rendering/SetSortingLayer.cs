using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingLayer : MonoBehaviour
{
    [SerializeField]
    Renderer rend;

    public void setSortingOrder(int order)
    {
        rend.sortingOrder = order;
    }
}
