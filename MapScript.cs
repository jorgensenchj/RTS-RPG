using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour {
    
    [SerializeField] bool mapOn;
    [SerializeField] Image mappy;


	// Use this for initialization
	void Start ()
    {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (mapOn == true)
        {
            if (Input.GetKeyUp(KeyCode.M))
              {
                print("map");
                mappy.enabled = false;
                mapOn = false;
            }
        }
        else
        if (mapOn == false)
            {
                if (Input.GetKeyUp(KeyCode.M))
                {
                    mappy.enabled = true;
                    mapOn = true;
                }
            }
        
    }
}
