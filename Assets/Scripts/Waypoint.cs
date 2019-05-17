using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int dridPos;
    public bool isExplored = false;
    public Waypoint exploreFrom;
    public bool isPaceable = true;
    [SerializeField] bool isTowerInPlace = false;
    [SerializeField] Tower towerToPlace;

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

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            //if(isPaceable && !isTowerInPlace)
            if (isPaceable)
            { 
                Debug.Log(gameObject.name+ " tower placement");

                if(!isTowerInPlace)
                { 
                    Instantiate(towerToPlace, transform.position, Quaternion.identity);
                    isTowerInPlace = true;
                }
                else
                    Debug.Log("There is already a tower here!");
            }
            else
                Debug.Log("Can't place here");
        }
        Debug.Log(gameObject.name);
    }
}
