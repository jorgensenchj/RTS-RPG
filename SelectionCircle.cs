using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCircle : MonoBehaviour
{

    public bool selection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selection == true)
        {
            gameObject.SetActive(true);
        }
        else
            if (selection == false)
        {
            gameObject.SetActive(false);
        }
    }
}
