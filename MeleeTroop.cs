using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MeleeTroop : MonoBehaviour {

    [SerializeField] bool isRangedUnit;
    //Animation TODO Move to animscript//
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private bool walking;
    public bool attacking;
    private bool enemyClicked;
    public bool striking;
    GameObject target;
    [SerializeField] float attackRadius = 2f;
    [SerializeField] float chaseRadius = 4f;
    [SerializeField] float distanceToEnemy;
    [SerializeField] float enemyHealth;
    [SerializeField] float troopHealth;
    public Vector3 clickspot;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        troopHealth = GetComponentInChildren<TrooperHealth>().currentHealth;
        ClickToMove();

        if (troopHealth > 0)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                    print("stop Running");
                walking = false;
                anim.SetBool("IsWalking", walking);
            }
            else
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                Walking();
            }

                if (distanceToEnemy <= attackRadius)
                {
                    if (walking == false)

                    {
                        if (target != null)
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
            
            else
                   if (distanceToEnemy >= attackRadius)
            {
                attacking = false;
                anim.SetBool("Attack", attacking);
            }

            Quaternion rotation = Quaternion.LookRotation(clickspot - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, .2f);

        }
    }


    void ClickToMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
              //  walking = true;
                enemyClicked = false;
                // transform.LookAt(hit.point + aimOffset)
                clickspot = hit.point;
                navMeshAgent.destination = hit.point;
            }

        }
    }

    void Walking()
    {
        walking = true;
        anim.SetBool("IsWalking", walking);
    }
}
     

    

