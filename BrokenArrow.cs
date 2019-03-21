using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenArrow : MonoBehaviour {

    public AudioClip strikeClip;
    AudioSource weaponAudio;
    public int damagePerHit = 20;

    // Use this for initialization
    void Start()
    {
        weaponAudio = GetComponent<AudioSource>();
        Destroy(gameObject, 1.5f);
    }

    
    void OnTriggerEnter(Collider collider)
    {


        if (collider.gameObject.tag == "Enemy")
        {
            
            
                EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(damagePerHit);
                    print("DAMAGE");

                }


                print("HIT enter");
                weaponAudio.clip = strikeClip;
                weaponAudio.Play();
        ///////////////Destroy after audio get to stick if able////////////
              //  Destroy(gameObject, .08f);
            
                

        }
    }
}
