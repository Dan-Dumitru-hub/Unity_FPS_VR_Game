using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvatarScript : MonoBehaviour
{
    // Start is called before the first frame update


    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    public Transform player;
    public bool dead=false;
    public GameObject canvas;

   
    
    private float coolDownTimer = 5f;

    // Update is called once per frame
    void Update()
    {

    if(!dead){
        GameObject target = GameObject.FindGameObjectWithTag("Player");
            this.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        //this.GetComponent<NavMeshAgent>().Warp(this.transform.position);
        this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(target.transform.position);
    }
    else{

        Destroy(canvas);
        Destroy(GetComponent<Rigidbody>());
        this.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
        animator.Play("Death");
        if(coolDownTimer>0)
        coolDownTimer -= Time.deltaTime;
        else{
            tag="Untagged";
            GetComponent<HitNewEnemy>().DestroyObject();

            }

        }


    }

    void Start()
    {
        
    }

    void Awake(){

        agent= GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void Z_run(){
        agent.speed=10f;
        animator.SetTrigger("Z_Run_InPlace");
    }

    public void Z_attack(){
        animator.SetTrigger("Attack");


        }

    
    
}
