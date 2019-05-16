using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int dridPos;
    public bool isExplored = false;
    public Waypoint exploreFrom;


    public int GetGridSize()
    {
        return gridSize;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2Int GetGridPos()
    {
        int roundXPos = Mathf.RoundToInt(transform.position.x / gridSize);
        int roundZPos = Mathf.RoundToInt(transform.position.z / gridSize);

        //print("Grid pos: "+new Vector2Int(roundXPos, roundZPos));
        return new Vector2Int(roundXPos, roundZPos);
    }

    public void SetTopColor(Color color)
    {
        //print(transform.Find("Top").GetComponent<MeshRenderer>());

        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
