﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase] 
[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    TextMesh textMesh;
    Waypoint waypoint;
    int gridSize = 0;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        gridSize = waypoint.GetGridSize();
    }

    void Start()
    {


    }
    void Update()
    {
        SnapToGrid();
        UpadateLabel();
    }


    void SnapToGrid()
    {

        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    void UpadateLabel()
    {

        textMesh = GetComponentInChildren<TextMesh>();
        string labelTxt = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelTxt;
        gameObject.name = labelTxt;
    }
}
