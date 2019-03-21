using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour {

    public GameObject[] enemys;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
