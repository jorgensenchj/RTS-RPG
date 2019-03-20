using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFigure : MonoBehaviour {

    public float distance = 3;
    public GameObject table;
    public float distance_to_table;
    public float dist;

    private void Update()
    {
        float dist = Vector3.Distance(table.transform.position, gameObject.transform.position);
    }

    private void OnMouseDrag()
    {
       

        distance_to_table = Camera.main.WorldToScreenPoint(table.transform.position).z;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, distance);
        Vector3 ObjPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_table));

        transform.position = ObjPosition;
    }


}
