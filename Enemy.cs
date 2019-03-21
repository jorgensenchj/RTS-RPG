using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    [SerializeField] bool footman;
    public GameObject target;
    public GameObject player;
    public GameObject placeHolder;
  //  public GameObject[] troops;
    public GameObject miguffin;
    public bool striking;
    NavMeshAgent nav;
    private bool Running;
    private bool attacking;
    private Animator anim;
    [SerializeField] float attackRadius = 2f;
    public float chaseRadius = 6f;
    public float distanceToEnemy;
    public float distanceToPlayer;
    public float distanceToTroops;
    Vector3 destination;
    [SerializeField] float troopHealth;
    [SerializeField] float health;
    [SerializeField] float timerSpeed = 4f;
    [SerializeField] float elapsed;
   // bool playertargeted;


    // Use this for initialization
    void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {



        health = GetComponentInChildren<EnemyHealth>().currentHealth;
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

     


        if (health > 0)
        {
           

            if (target != null)
            {
                troopHealth = target.GetComponent<TrooperHealth>().currentHealth;
                MoveToOpponent();
            }
            if (target != null)
            {
                if (troopHealth <= 0)
                {
                    print("fhdafshf");
                    target = null;
                    TargetDead();
                }
            }


            //   if (troops.Length > 0)
            //   {
            //       distanceToTroops = Vector3.Distance(troops[0].transform.position, transform.position);
            //    }

            if (target == null)

            {
                
                attacking = false;
                anim.SetBool("Attack", attacking);
            }
            
            if (target != null)
            {
                elapsed = 0;
            }
            



                if (distanceToPlayer <= chaseRadius) 
                {
                  
                
                if (target == null)
                    {
                    elapsed += Time.deltaTime;
                    if (elapsed > timerSpeed)
                    {
                        target = player;

                    }
                    


                    if (troopHealth > 0 )
                        {    
                          MoveToOpponent();
                        }
                    }
                }
            

/*
            if (distanceToPlayer <= chaseRadius)

            {
                if (target == null)
                {
                    target = player;
                    if (troopHealth > 0)
                    {
                        MoveToOpponent();
                    }
                }


            }
*/


            //   foreach (GameObject trooper in troops)
            //   {
            //       distanceToTroops = Vector3.Distance(trooper.transform.position, transform.position);
            //       if (distanceToTroops < chaseRadius)
            //      {
            //          target = trooper;
            //          if (troopHealth > 0)
            //         {
            //              MoveToOpponent();
            //           }
            //       }

            //   }


            //    else

            if (distanceToEnemy >= chaseRadius)
            {
                //  target = miguffin;
                nav.SetDestination(target.transform.position);
                //   distanceToEnemy = Vector3.Distance(target.transform.position, transform.position);
            }




            if (target != null)
            {


                if (distanceToEnemy <= attackRadius)
                {
                    if (troopHealth > 0)
                    {
                        attacking = true;
                        anim.SetBool("Attack", attacking);
                        transform.LookAt(target.transform);
                        Running = false;
                        anim.SetBool("Run", Running);
                    }
                    else
                        if (troopHealth <= 0)
                    {
                        attacking = false;
                        anim.SetBool("Attack", attacking);
                    }

                    //  DamageEnemyEvent();
                    //  HitChance();


                }


                else

                if (distanceToEnemy >= attackRadius)
                {
                    if (troopHealth > 0)
                    {
                        Running = true;
                        anim.SetBool("Run", Running);
                        attacking = false;
                        anim.SetBool("Attack", attacking);
                    }


                }
            }

        }
    }
        //   troops = GameObject.FindGameObjectsWithTag("Troop");
       
            
    
    void TargetDead()
    {
        target = null;
        
    }

    
    void MoveToOpponent()
    {
        if (target != null)
        { 
            if (troopHealth > 0)
            {
                //Health script if health is greater than 0
                distanceToEnemy = Vector3.Distance(target.transform.position, transform.position);
                transform.LookAt(target.transform);
                if (health > 0)
                {
                    nav.SetDestination(target.transform.position);
                }
               
            }  
            else
             if (troopHealth <= 0)
            {
                target = placeHolder;
            }
        }
    }
        



    public void StrikeOn()
    {
        Debug.Log("strike");
        striking = true;
    }
    public void StrikeOff()
    {
        striking = false;
    }
    void OnDrawGizmos()
    {


        //Draw attack shpere
        Gizmos.color = new Color(0, 0255f, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        //Draw Chase shpere
        Gizmos.color = new Color(0, 0, 0255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}


