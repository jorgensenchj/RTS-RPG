using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MeleeTrooper : MonoBehaviour {

    TroopSelection troopSelection;
    private Animator anim;
    public NavMeshAgent navMeshAgent;
    private bool walking;
    public bool attacking;
    private bool enemyClicked;
    public bool striking;
    [SerializeField] GameObject enemytarget;
    [SerializeField] GameObject target;
    [SerializeField] float distanceToBadguy;
    [SerializeField] float distanceToEnemy;
    public float chaseRad;
    public bool killEnemy;
    public bool selected;
    [SerializeField] float enemyHealth;
    [SerializeField] float troopHealth;
    [SerializeField] float attackRadius = 2f;
    public Vector3 clickspot;
    int index;
    Transform targetedEnemy;




    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        RegisterForMouseEvent();
    }
    private void RegisterForMouseEvent()
    {
        var cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.onMouseOverEnemy += OnMouseOverEnemy;
        //   cameraRaycaster.onMouseOverPotentiallyWalkable += OnMouseOverPotentiallyWalkable;
    }
    // Update is called once per frame
    void Update ()
    {
        index = GetComponentInChildren<TroopSelection>().findindex;
        
        chaseRad = GetComponentInChildren<TroopSelection>().chaseRadius;
        distanceToBadguy = GetComponentInChildren<TroopSelection>().distanceToEnemy;
        selected = GetComponentInChildren<TroopSelection>().selectCircle;
        troopHealth = GetComponentInChildren<TrooperHealth>().currentHealth;
        enemytarget = GetComponentInChildren<TroopSelection>().target;
        



        if (enemytarget != null)
        {
            enemyHealth = enemytarget.GetComponent<EnemyHealth>().currentHealth;
        }
     
           
        

            

        if (enemytarget == null)

        {

            attacking = false;
            anim.SetBool("Attack", attacking);
        }
       
            if (killEnemy == true)
            {
                KillBaddie();
            }
            if (distanceToBadguy <= attackRadius)
            {

                if (enemytarget != null)
                {
                if(enemyHealth > 0)
                {
                    transform.LookAt(enemytarget.transform);
                    EnemyClose();
                }
                  
                }

            }
            if (troopHealth <= 0)
            {
                selected = false;
            }
        if (enemyHealth <= 0)
        {
            enemytarget = null;
        }

        if (enemyHealth <= 20)
        {
            if (enemytarget != null)
            {
                target = null;
            }
        }
            
               
            
           
           


            if (selected == true)
            {
                ClickToMove();
            }
        if (troopHealth > 0)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                    print("stop Running");
                walking = false;
            }
            anim.SetBool("IsWalking", walking);

            if (enemyHealth <= 0)
            {

                attacking = false;
                anim.SetBool("Attack", attacking);
                enemytarget = null;

            }
        }
            if (enemytarget == null)
            {
                return;
            }
        
            

        


    }
    void OnMouseOverEnemy(Enemy enemy)
    {
        if (selected == true)
        {
            if (Input.GetMouseButton(1))
            {
                target = enemy.gameObject;
                killEnemy = true;
                transform.LookAt(target.transform);

            }
        }

    }

    void ClickToMove()
    {
        Quaternion rotation = Quaternion.LookRotation(clickspot - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, .2f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Enemy"))
                {

                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }

                else
                {
                    walking = true;
                    enemyClicked = false;
                    // transform.LookAt(hit.point + aimOffset);
                    clickspot = hit.point + TroopManager.instance.positions[index];




                    navMeshAgent.destination = hit.point + TroopManager.instance.positions[index];



                    navMeshAgent.isStopped = false;
                    //   killEnemy = false;
                }
            }
        }
        if (enemyClicked)
        {

            MoveAndAttack();

        }
        //get health
        //     troopHealth = GetComponentInChildren<TrooperHealth>().currentHealth;
        if (troopHealth > 0)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                    
                walking = false;
            }
            else

            {
                walking = true;
            }

            anim.SetBool("IsWalking", walking);
        }
    }



    void KillBaddie()
    
        {
        if (troopHealth > 0)
        {
            if (target != null)
            {
                transform.LookAt(target.transform);
                navMeshAgent.stoppingDistance = 1;
                navMeshAgent.SetDestination(target.transform.position);
                //    if (isRangedUnit == true)
                //       {
                //        navMeshAgent.stoppingDistance = 8;
                //     }
                //    else
                //     if (isRangedUnit == false)
                //     {
                //         navMeshAgent.stoppingDistance = 1;
                //     }
                //    }

            }
            else
            if (killEnemy == false)
            {
                navMeshAgent.stoppingDistance = 1;
            }
        }
      
    }
    void EnemyClose()
    {
        if (walking == false)

        {
            if (enemytarget != null)
            {
               
                
                    if (enemyHealth > 0)
                    {

                        attacking = true;
                        anim.SetBool("Attack", attacking);
                    }
                
              
                else

                if (enemyHealth <= 0)
                {

                    attacking = false;
                    anim.SetBool("Attack", attacking);
                }
             
                
            }
        }
    }

    void MoveAndAttack()
    {


        if (target != null)
        {
            if (distanceToEnemy <= attackRadius)
            {
                if (Input.GetMouseButton(1))
                {


                    navMeshAgent.SetDestination(target.transform.position);

                    transform.LookAt(target.transform);
                    killEnemy = true;
                  //  attacking = true;
                  //  anim.SetBool("Attack", attacking);


                }
            }
            

           



            if (enemyHealth <= 0)
            {
               
                    attacking = false;
                    anim.SetBool("Attack", attacking);
                    enemytarget = null;

                
                
               
            }
            if (enemytarget == null)
            {
                return;
            }
        }
    }
    void OnDrawGizmos()
    {

        //Draw attack shpere
        Gizmos.color = new Color(0, 0255f, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        //Draw Chase shpere
        Gizmos.color = new Color(0, 0, 0255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRad);
    }
}
