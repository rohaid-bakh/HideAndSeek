using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool walkable;
    public Vector3 worldPosition;

    public Node(bool walk, Vector3 worldPos)
    {
        walkable = walk;
        worldPosition = worldPos;
    }
}
