using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOn : MonoBehaviour {
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    [SerializeField] float distanceToPlayer;
    [SerializeField] float activationRange;
    [SerializeField] float health;
    EnemyHealth enemyHealth;

    // Use this for initialization
    void Start ()
    {
        enemyHealth = GetComponentInChildren<EnemyHealth>();
	}

    // Update is called once per frame
    void Update()
    {
        if( enemy != null)
        {
            health = enemy.GetComponentInChildren<EnemyHealth>().currentHealth;
            if (health <= 0)
            {
                enemy = null;
                Destroy(gameObject, 15f);
            }
            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceToPlayer >= activationRange)
            {
                EnemyOff();
            }
            else
                  if (distanceToPlayer < activationRange)
            {
                EnemyIsOn();
            }
        }
       
    }
        void EnemyIsOn()
    {
        if (enemy != null)
        {
            enemy.SetActive(true);
        }
        return;

    }
    void EnemyOff()
    {
        enemy.SetActive(false);
    }
}
