using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [Range(1f,10f)] [SerializeField] float gridSise = 10f;
    TextMesh textMesh;

    void Start()
    {


    }
    void Update()
    {
        Vector3 snapPos;

        float roundXPos = Mathf.RoundToInt(transform.position.x / gridSise);
        snapPos.x = roundXPos * 10f;

        float roundZPos = Mathf.RoundToInt(transform.position.z / gridSise);
        snapPos.z = roundZPos * 10f;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x + "," + snapPos.z;

       

        Debug.Log("Editor causes this Update");
    }
}
