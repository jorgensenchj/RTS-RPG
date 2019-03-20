using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxe : MonoBehaviour {


    public AudioClip strikeClip;
    public AudioClip strikeClip2;
    AudioSource weaponAudio;
    public int damagePerHit = 1;

    // Use this for initialization
    void Start()
    {
        weaponAudio = GetComponent<AudioSource>();
    }

    void OnTriggerExit(Collider collider)
    {
        var strike = GetComponentInParent<TroopSelection>().striking;
        if (collider.gameObject.tag == "Tree")
        {
            if (strike == true)
            {
                print("HIT TREE exit");
            }
            else
                print("some anim Issue");

        }
    }
    void OnTriggerEnter(Collider collider)
    {

        var strike = GetComponentInParent<TroopSelection>().striking;
        if (collider.gameObject.tag == "Tree")
        {
            if (strike == true)
            {
                TreeResource treeHealth = collider.GetComponent<TreeResource>();
                if (treeHealth != null)
                {
                    // ... the enemy should take damage.
                    treeHealth.TakeDamage(damagePerHit);
                    print("Tree DAMAGE");

                }


                print("HIT enter");
                weaponAudio.clip = strikeClip2;
                weaponAudio.Play();

            }
            else
                print("Not a Hit");

        }
    }
}

