﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraOrbit : MonoBehaviour
{

    public float turnSpeed = 4.0f;
    public GameObject player;

    private Vector3 offset;
    public float ZoomAmount = 2; //With Positive and negative values
    public float MaxToClamp = 3;
  
    public float ROTSpeed = 10;
    [SerializeField] Vector3 pos;
    [SerializeField] float distanceToPlayer;
    [SerializeField] float XRot = 6;
    [SerializeField] float yRot = 8;
    [SerializeField] float ZRot = 5;


    void Start()
    {
          offset = new Vector3(player.transform.rotation.x + XRot, player.transform.position.y + yRot, player.transform.position.z + ZRot);
      
    }
    
    void LateUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= 25)
        {
            ZoomInAndOut();
        }

       

        if (Input.GetMouseButton(3))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            transform.position = player.transform.position + offset;
           
            transform.LookAt(player.transform.position);
        
            Debug.Log("Pressed middle click.");
        }
        if (Input.GetMouseButton(2))
        {
            Debug.Log("Pressed click.");
        }
       
    }
        private void ZoomInAndOut()
        {
            pos = transform.position;
            ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
            ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
            var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));

            gameObject.transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

        }

    
}
