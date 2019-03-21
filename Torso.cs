using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            print("HIT");
        }
    }
}
