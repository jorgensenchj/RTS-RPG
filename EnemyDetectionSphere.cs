using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSphere : MonoBehaviour {

   
  public List<GameObject>enemys  = new List<GameObject>();
  //  public GameObject[] badguys;
    [SerializeField] GameObject player;
    public float sizeOfEnemy;
    public AudioClip Comannder;
    public AudioClip oneEnemy;
    public AudioClip twoEnemy;
    public AudioClip threeEnemy;
    public AudioClip fourEnemy;
    public AudioClip fiveEnemy;
    public AudioClip sixEnemy;
    public AudioClip largeEnemy;
    public AudioClip intel;
    AudioSource audioSpeak;
    AudioSource command;
    public float distanceToPlayer;
    float distanceToSpeak = 3; 
    public bool playedCommander;


    // Use this for initialization
    void Start ()
    {
        audioSpeak = GetComponent<AudioSource>();
        command = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
         sizeOfEnemy = enemys.Count;
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(sizeOfEnemy == 1)
        {
            intel = oneEnemy;
        }
        if (sizeOfEnemy == 2)
        {
            intel = twoEnemy;
        }
        if (sizeOfEnemy == 3)
        {
            intel = threeEnemy;
        }
        if (sizeOfEnemy == 4)
        {
             intel = fourEnemy;
        }

        if (distanceToPlayer <= distanceToSpeak)
        {
            //  GetComponent<AudioSource>().loop = true;


            StartCoroutine(PlayedAudio());



        }

    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (!enemys.Contains(collider.gameObject))
            {
                enemys.Add(collider.gameObject);
            }
         


        }
    }
    IEnumerator PlayedAudio()
    {
        
        command.clip = Comannder;
        command.Play();
        yield return new WaitForSeconds(audioSpeak.clip.length);
       
      

       
    }
    IEnumerator playIntel()
    {
            
    
        if(playedCommander == true)
        {
            audioSpeak.clip = intel;
            audioSpeak.Play();
            yield return new WaitForSeconds(audioSpeak.clip.length);
        }
            
            
        
       
        
    }





}
