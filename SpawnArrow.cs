using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class SpawnArrow : MonoBehaviour {

    public Rigidbody arrow;
    public Transform arrowSpawn;
    public GameObject target;
    Vector3 aimOffset = new Vector3(0, 2, 0);
    

    // Use this for initialization
    void Start ()
    {
       
        //  arrow = Resources.Load("WK_arrow") as GameObject;
    }
    void Update()
    {
        target = GetComponentInParent<ArcherTrooper>().enemytarget; 
    }
        // Update is called once per frame
        public void ArrowLaunch ()
    {
        if(target!= null)
        {
            transform.LookAt(target.transform.position + aimOffset);
            Rigidbody arrowInstance;
            arrowInstance = Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation) as Rigidbody;
            arrowInstance.AddForce(arrowSpawn.forward * 1000);
        }
            
        
    }
  //  void SpawnArrow()
//	{
//		GameObject newArrow = Instantiate (arrowToUse, arrowSocket.transform.position, Quaternion.identity);
//		Arrow arrowComponent = newArrow.GetComponent<Arrow> ();
//		arrowComponent.SetDamage (damagePerShot);
//		Vector3 unitVectorToPlayer = (player.transform.position + aimOffSet - arrowSocket.transform.position).normalized;
//		float arrowSpeed = arrowComponent.arrowSpeed;
//		newArrow.GetComponent<Rigidbody> ().velocity = unitVectorToPlayer * arrowSpeed;

//            }
}
