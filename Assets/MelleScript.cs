using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    private Animator animator;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public Element[] elementstospawn;


    
    public bool dead = false;
    public GameObject canvas;
    private float coolDownTimer = 5f;
    private bool spawnedItem = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("VRCamera").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // print(coolDownTimer);
        if (!dead && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().dead)
        {
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();

        }
        else if (dead)
        {
            Destroy(canvas);
            Destroy(GetComponent<Rigidbody>());
            this.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
            animator.Play("Death");

            
            if (coolDownTimer >3.5f)
                coolDownTimer -= Time.deltaTime;
            else if (coolDownTimer <= 3.5f && coolDownTimer>0f )
            {
                GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
                if (spawnedItem == false && Random.Range(0, 10.0f)>4.0f && scripts.GetComponent<pickupcount>().available>0 ){
                    scripts.GetComponent<pickupcount>().available--;
                    
                    GameObject newElement = Instantiate(elementstospawn[0].GetRandom());
                        
                    newElement.transform.position = transform.position + new Vector3(0,1,0);
                    spawnedItem = true;

                    if (newElement.tag == "Ammo")
                        newElement.GetComponent<destroyonpickupammo>().Invoke("destroyAfterTime", 10f);
                    else
                    {
                        newElement.GetComponent<destroyonpickup>().Invoke("destroyAfterTime", 10f);
                    }

                }
                else
                {
                    spawnedItem = true;
                }
                coolDownTimer -= Time.deltaTime;
            }
            else
            {
                tag = "Untagged";
                GetComponent<HitMelleenemy>().DestroyObject();


                // Destroy(gameObject);

            }
            //TakeDamage(0);
        }
        
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        //transform.LookAt(player);

        if (!alreadyAttacked)
        {
            animator.SetTrigger("Attack");
            ///Attack code here
           

         

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health = 0;

       // if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
