using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitSphere : MonoBehaviour {

    public bool strike;
    public GameObject hitableTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.tag == "Enemy")
        {
            hitableTarget = collider.gameObject;
            strike = true;
        }
       
    }
    void OnTriggerExit(Collider collider)
    {

        if (collider.gameObject.tag == "Enemy")
        {
            hitableTarget = null;
            strike = false;
        }

    }
}
