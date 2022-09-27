using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static List<Transform> GetAllChilds(this Transform transform)
    {
        var childs = new List<Transform>();
        foreach (Transform child in transform)
        {
            childs.Add(child);
        }
        return childs;
    }
}
