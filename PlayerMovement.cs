using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 6f;
    public float v;
    Vector3 movement;                  
    Animator anim;                    
    Rigidbody playerRigidbody;
    bool Running;
    public bool striking;

    // Use this for initialization
    void Start ()
    {
        //change

        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        Moveing();
        
        if (Input.GetButtonDown("Jump")&& Running == false)
        {
            Attack();
        }

    }

    private void Moveing()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        v = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, h, 0);
        transform.Translate(0, 0, v);

        Animating(h, v);
       
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool Running = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("Running", Running);
    }
    void Attack ()
    {
        if (Running == false)
        {
            anim.SetTrigger("Attack");
        }
     
            
        
    }

}
