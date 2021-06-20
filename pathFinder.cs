using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

     Node currentSearchNode;
     Node startNode;
     Node destinationNode;
     Dictionary<Vector2Int,Node> reached = new Dictionary<Vector2Int, Node>();
     Queue<Node> fronier = new Queue<Node>();
    Vector2Int[] directions = { Vector2Int.right,Vector2Int.left,Vector2Int.up,Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int,Node> grid = new Dictionary<Vector2Int, Node>();
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
         startNode = new Node(startCoordinates,true);
         destinationNode = new Node(destinationCoordinates,true);
    }
    void Start()
    {
        BreadthFirstSearch();
    }
    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(neighborCoords))
            {
               neighbors.Add(grid[neighborCoords]);
                
            }
        }
        foreach(Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                reached.Add(neighbor.coordinates,neighbor);
                fronier.Enqueue(neighbor);
            }
        }
    }
    void BreadthFirstSearch()
    {
        bool isRunning = true;
        fronier.Enqueue(startNode);
        reached.Add(startCoordinates,startNode);
        while(fronier.Count>0 && isRunning)
        {
            currentSearchNode = fronier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    } 

   
}
