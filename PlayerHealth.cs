using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;            
    public int currentHealth;
    public AudioClip deathClip;
    private NavMeshAgent navMeshAgent;
    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    public bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
    public Vector3 hitPoint;
    public Slider healthslider;


    // Use this for initialization
    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //   enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        //    hitParticles.transform.position = hitPoint;

        // And play the particles.
        //    hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
           

            // ... the enemy is dead.
            Death();
        }

    }
    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        //  capsuleCollider.isTrigger = true;
        capsuleCollider.enabled = false;
        navMeshAgent.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        // Tell the animator that the enemy is dead.
        anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }
}
