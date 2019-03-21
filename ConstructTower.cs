using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructTower : MonoBehaviour
{
    [SerializeField] GameObject target;
    public bool compleated;
    public GameObject tower;
    public GameObject pillars;
    public int woodResource = 0;
    public int wood;
    WorkerGather workerGather;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (woodResource >=10)
        {
            compleated = true;
        }
        if (compleated == true)
        {
            tower.SetActive(true);
            pillars.SetActive(false);
        }
        else
        if (compleated == false)
        {
            tower.SetActive(false);
            pillars.SetActive(true);
        }
      
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Troop")
        {
            target = collider.gameObject;
            collider.GetComponent<WorkerGather>().woodInventoryAmount--;
            wood = wood - 1;
            woodResource = woodResource + 1;

        }
    }
}
