using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconInfo : MonoBehaviour
{

    //   public TroopCardData card;

    public static IconInfo instance;
    public Text troopName;

    public Image Icon0;
    public Image Icon1;
    public Image Icon2;
    public Image Icon3;
    public Image Icon4;
    public Image Icon5;
    public Image Icon6;
    public Image Icon7;
    public Image Icon8;
    public Image Icon9;

    public Sprite placeHolder;
    public TroopSelection trooper;
    public TroopManager manager;
    public GameObject placeHolderObject;

    public GameObject troop0;
    public GameObject troop1;
    public GameObject troop2;
    public GameObject troop3;
    public GameObject troop4;
    public GameObject troop5;
    public GameObject troop6;
    public GameObject troop7;
    public GameObject troop8;
    public GameObject troop9;


    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start()
    {

        trooper = GetComponent<TroopSelection>();
        manager = GetComponent<TroopManager>();
        troop0 = placeHolderObject;
        troop1 = placeHolderObject;
        troop2 = placeHolderObject;
        troop3 = placeHolderObject;
        troop4 = placeHolderObject;
        troop5 = placeHolderObject;
        troop6 = placeHolderObject;
        troop7 = placeHolderObject;
        troop8 = placeHolderObject;
        troop9 = placeHolderObject;

    }

    // Update is called once per frame
    void Update()
    {
        manager = GetComponent<TroopManager>();
        //spot 1


        ////////////////SPOT#0//////////////////
    
        if (troop0 != placeHolderObject)
        {
       
            if (troop0 != null)
            {
                print("NOT NULL");
                if (troop0.GetComponent<TroopSelection>().selectCircle == true && troop0.GetComponent<TrooperHealth>().isDead == false)
                {
                 //   Icon0.sprite = troop0.GetComponent<TroopSelection>().card.Icon;
                }
                else
                   if (troop0.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop0 = placeHolderObject;
                    Icon0.sprite = placeHolder;
                }
                else
                    if(troop0.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop0 = null;
                    troop0 = placeHolderObject;
                    Icon0.sprite = placeHolder;
                }
            }
        }
        ////////////////SPOT#1//////////////////
        if (troop1 != placeHolderObject)
        {
            if (troop1 != null)
            {
                if (troop1.GetComponent<TroopSelection>().selectCircle == true && troop1.GetComponent<TrooperHealth>().isDead == false)
                {
                  //  Icon1.sprite = troop1.GetComponent<TroopSelection>().card.Icon;
                }

                else
              if (troop1.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop1 = placeHolderObject;
                    Icon1.sprite = placeHolder;
                }
                else
                    if (troop1.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop1 = placeHolderObject;
                    Icon1.sprite = placeHolder;
                }
            }
        }
        ////////////////SPOT#2//////////////////
        if (troop2 != placeHolderObject)
        {
            if (troop2 != null)
            {
                if (troop2.GetComponent<TroopSelection>().selectCircle == true && troop2.GetComponent<TrooperHealth>().isDead == false)
                {
                  //  Icon2.sprite = troop2.GetComponent<TroopSelection>().card.Icon;
                }

                else
              if (troop2.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop2 = placeHolderObject;
                    Icon2.sprite = placeHolder;
                }
                else
                    if (troop2.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop2 = placeHolderObject;
                    Icon2.sprite = placeHolder;
                }
            }
        }
        ////////////////SPOT#3//////////////////
        if (troop3 != placeHolderObject)
        {
            if (troop3 != null)
            {
                if (troop3.GetComponent<TroopSelection>().selectCircle == true && troop3.GetComponent<TrooperHealth>().isDead == false)
                {
                 //   Icon3.sprite = troop3.GetComponent<TroopSelection>().card.Icon;
                }
                else
               if (troop3.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop3 = placeHolderObject;
                    Icon3.sprite = placeHolder;
                }
                else
                    if (troop3.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop3 = placeHolderObject;
                    Icon3.sprite = placeHolder;
                }
            }
        }
        ////////////////SPOT#4//////////////////
        if (troop4 != placeHolderObject)
        {
            if (troop4 != null)
            {
                if (troop4.GetComponent<TroopSelection>().selectCircle == true && troop4.GetComponent<TrooperHealth>().isDead == false)
                {
                 //   Icon4.sprite = troop4.GetComponent<TroopSelection>().card.Icon;
                }
                else
               if (troop4.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop4 = placeHolderObject;
                    Icon4.sprite = placeHolder;
                }
                else
                    if (troop4.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop4 = placeHolderObject;
                    Icon4.sprite = placeHolder;
                }
            }
        }
        ////////////////SPOT#5//////////////////
        if (troop5 != placeHolderObject)
        {
            if (troop5 != null)
            {
                if (troop5.GetComponent<TroopSelection>().selectCircle == true && troop5.GetComponent<TrooperHealth>().isDead == false)
                {
                  //  Icon5.sprite = troop5.GetComponent<TroopSelection>().card.Icon;
                }
                else
               if (troop5.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop5 = placeHolderObject;
                    Icon5.sprite = placeHolder;
                }
                else
                    if (troop5.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop5 = placeHolderObject;
                    Icon5.sprite = placeHolder;
                }
            }
        }
        ////////////////SPOT#6//////////////////
        if (troop6 != placeHolderObject)
        {
            
            if (troop6 != null)
            {
                if (troop6.GetComponent<TroopSelection>().selectCircle == true && troop6.GetComponent<TrooperHealth>().isDead == false)
                {
                  //  Icon6.sprite = troop6.GetComponent<TroopSelection>().card.Icon;
                }
                else
               if (troop6.GetComponent<TroopSelection>().selectCircle == false)
                {
                    troop6 = placeHolderObject;
                    Icon6.sprite = placeHolder;

                }
                else
                    if (troop6.GetComponent<TrooperHealth>().isDead == true)
                {
                    troop6 = placeHolderObject;
                    Icon6.sprite = placeHolder;
                }
            }
            ////////////////SPOT#7//////////////////
            if (troop7 != placeHolderObject)
            {
                if (troop7 != null)
                {
                    if (troop7.GetComponent<TroopSelection>().selectCircle == true && troop7.GetComponent<TrooperHealth>().isDead == false)
                    {
                     //   Icon7.sprite = troop7.GetComponent<TroopSelection>().card.Icon;
                    }
                    else
               if (troop7.GetComponent<TroopSelection>().selectCircle == false)
                    {
                        troop7 = placeHolderObject;
                        Icon7.sprite = placeHolder;
                    }
                    else
                    if (troop7.GetComponent<TrooperHealth>().isDead == true)
                    {
                        troop7 = placeHolderObject;
                        Icon7.sprite = placeHolder;
                    }
                }
            }
            ////////////////SPOT#8//////////////////
            if (troop8 != placeHolderObject)
            {
                if (troop8 != null)
                {
                    if (troop8.GetComponent<TroopSelection>().selectCircle == true && troop8.GetComponent<TrooperHealth>().isDead == false)
                    {
                     //   Icon8.sprite = troop8.GetComponent<TroopSelection>().card.Icon;
                    }
                    else
               if (troop8.GetComponent<TroopSelection>().selectCircle == false)
                    {
                        troop8 = placeHolderObject;
                        Icon8.sprite = placeHolder;
                    }
                    else
                    if (troop8.GetComponent<TrooperHealth>().isDead == true)
                    {
                        troop8 = placeHolderObject;
                        Icon8.sprite = placeHolder;
                    }
                }
            }
            ////////////////SPOT#9//////////////////
            if (troop9 != placeHolderObject)
            {
                if (troop9 != null)
                {
                    if (troop9.GetComponent<TroopSelection>().selectCircle == true && troop9.GetComponent<TrooperHealth>().isDead == false)
                    {
                     //   Icon9.sprite = troop9.GetComponent<TroopSelection>().card.Icon;
                    }
                    else
               if (troop9.GetComponent<TroopSelection>().selectCircle == false)
                    {
                        troop9 = placeHolderObject;
                        Icon9.sprite = placeHolder;
                    }
                    else
                    if (troop9.GetComponent<TrooperHealth>().isDead == true)
                    {
                        troop9 = placeHolderObject;
                        Icon9.sprite = placeHolder;
                    }
                }
            }
        }
    }
}



    

