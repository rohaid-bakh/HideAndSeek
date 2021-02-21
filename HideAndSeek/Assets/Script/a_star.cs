using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_star : MonoBehaviour
{
    Grid grid;
    // Start is called before the first frame update
    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    // Update is called once per frame
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            //current = node in open set with lowest fCost
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }
            //remove current node from open
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return;
            }

            foreach (Node neighbor in grid.getNeighbors(currentNode))
            {
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbour = currentNode.gCost + getDistance(currentNode, neighbor);
                if (newCostToNeighbour < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbour;
                    neighbor.hCost = getDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }
    }
    int getDistance(Node nodeStart, Node nodeEnd)
    {
        int dstX = Mathf.Abs(nodeStart.gridX - nodeEnd.gridX);
        int dstY = Mathf.Abs(nodeStart.gridY - nodeEnd.gridY);

        if (dstX > dstY)
                return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
