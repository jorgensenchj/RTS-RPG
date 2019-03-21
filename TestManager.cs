using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject[] troops;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        troops = GameObject.FindGameObjectsWithTag("Troop");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");



        foreach (GameObject enemy in enemys)
        {
            var chaserRadius = enemy.GetComponent<Enemy>().chaseRadius;
            foreach (GameObject troop in troops)
            {
                var distanceToTroop = Vector3.Distance(enemy.transform.position, troop.transform.position);


                if (distanceToTroop < chaserRadius)
                {

                    print(enemy + "Attack" + troop);
                    if(enemy.GetComponent<Enemy>().target == null)
                    {
                        enemy.GetComponent<Enemy>().target = troop;
                    }
                   

                }

            }
        }
        //TODO TROOPSELECTION MAY CHANGE IF IT DOES THIS WILL BREAK//
        foreach (GameObject troop in troops)
        {

            var chaserRadius = troop.GetComponent<TroopSelection>().chaseRadius;
            foreach (GameObject enemy in enemys)
            {
                var distanceToEnemy = Vector3.Distance(troop.transform.position, enemy.transform.position);


                if (distanceToEnemy < chaserRadius)
                {

                    print(troop + "Attack" + enemy);
                    troop.GetComponent<TroopSelection>().target = enemy;

                }

            }



        }
    }
}

