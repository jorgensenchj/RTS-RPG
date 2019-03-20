using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public AudioClip strikeClip;
    AudioSource weaponAudio;
    public int damagePerHit = 20;

    // Use this for initialization
    void Start()
    {
        weaponAudio = GetComponent<AudioSource>();
    }

 /*   void OnTriggerExit(Collider collider)
    {
        var strike = GetComponentInParent<Enemy>().striking;
        if (collider.gameObject.tag == "Player"  )
        {
            if (strike == true)
            {
                TrooperHealth trooperHealth = collider.GetComponent<TrooperHealth>();
                if(trooperHealth != null)
                {
                    trooperHealth.TakeDamage(damagePerHit);
                    print("HIT exit");
                }
                print("HIT enter");
                weaponAudio.clip = strikeClip;
                weaponAudio.Play();

            }
            else
                print("Not a Hit");
      
        }
        
        if (collider.gameObject.tag == "Troop")
        {
            if (strike == true)
            {
                print("HIT exit");
            }
            else
                print("some anim Issue ENEMY");

        }

    }
*/

    void OnTriggerEnter(Collider collider)
    {
        var strike = GetComponentInParent<Enemy>().striking;
       
        if (collider.gameObject.tag == "Player")
        {
            TrooperHealth trooperHealth = collider.GetComponent<TrooperHealth>();

            if (trooperHealth != null)

                if (strike == true)
            {
                 trooperHealth.TakeDamage(damagePerHit);
                print("HIT enter");
                weaponAudio.clip = strikeClip;
                weaponAudio.Play();

            }
            else
                print("Not a Hit ENemy");

        }
        if (collider.gameObject.tag == "Troop")
        {
            TrooperHealth trooperHealth = collider.GetComponent<TrooperHealth>();
           
            if (trooperHealth != null)
         {
                if (strike == true)
                {
                    trooperHealth.TakeDamage(damagePerHit);
                    print("HIT exit");
                    print("HIT enter");
                    weaponAudio.clip = strikeClip;
                    weaponAudio.Play();


                } 
            }
           
        }
        else
            print("Not a Hit");

    }
    }

