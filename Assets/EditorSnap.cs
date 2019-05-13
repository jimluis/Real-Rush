using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
   [Range(1f,10f)] [SerializeField] float gridSise = 10f;

    void Update()
    {
        Vector3 snapPos;
        float roundXPos = Mathf.RoundToInt(transform.position.x / gridSise);
        snapPos.x = roundXPos * 10f;

        float roundZPos = Mathf.RoundToInt(transform.position.z / gridSise);
        snapPos.z = roundZPos * 10f;

       // Debug.Log("transform.position.x: " + transform.position.x + "roundPos: " + roundPos + " - snapPos.x : " + snapPos.x);

        //snapPos.z = 0f;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        Debug.Log("Editor causes this Update");
    }
}
