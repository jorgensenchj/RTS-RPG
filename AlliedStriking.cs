using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedStriking : MonoBehaviour {

    public bool striking;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StrikeOn()
    {
        Debug.Log("strike");
        striking = true;
    }
    public void StrikeOff()
    {
        striking = false;
    }


}
