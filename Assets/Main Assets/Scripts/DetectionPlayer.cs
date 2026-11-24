using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectionPlayer : MonoBehaviour
{
    // Start is called before the first frame update


    public bool indetection=false;
    public DateTime nextDmg;
    public float fightafte;
    public GameObject obj;

    bool alreadyAttacked;


    public AvatarScript scr;
    void Awake()
    {
        nextDmg=DateTime.Now;

    }

    // Update is called once per frame
    void FixedUpdate()
    {   //obj.GetComponent<damageCheck>().damage=0f;
        
        if (indetection){
           // print("indetection");
/*
            if(ok==1){
        obj.GetComponent<damageCheck>().damage=0.34f;
        ok=0;
       }
       else 
       obj.GetComponent<damageCheck>().damage=0f;*/

            FightIndetection();
        }
        
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player"){
             //obj.GetComponent<damageCheck>().damage=0.34f;
            indetection=true;
        }

    }

    private void OnTriggerExit(Collider other){
        if (other.tag=="Player"){
              
            indetection=false;
        }

    }

    public void FightIndetection(){
      
        if (!alreadyAttacked)
        {    scr.Z_attack();
            
            ///Attack code here
            //obj.GetComponent<damageCheck>().damage=0f;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), fightafte);
            obj.GetComponent<damageCheck>().damage=0.34f;
        }
    }


     private void ResetAttack()
    {
        alreadyAttacked = false;
        obj.GetComponent<damageCheck>().damage=0f;
    }







}
