﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour {
    [HideInInspector]
    public List<Collider>colliders = new List<Collider>();
    private bool isSelected;


    private void OnGUI()
    {
        if (isSelected)
        {
            GUI.Button(new Rect(100, 200, 100, 30), name);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Building")
        {
            colliders.Add(c);
        }
    }
    private void OnTriggerExit(Collider c)
    {
        if (c.tag == "Building")
        {
            colliders.Remove(c);
        }
    }

    public void SetSelected(bool s)
    {

    }
}
