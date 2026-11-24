using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyfollow : MonoBehaviour

{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<NavMeshAgent>().enabled = true;
        //this.GetComponent<NavMeshAgent>().Warp(this.transform.position);
        this.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }
}
