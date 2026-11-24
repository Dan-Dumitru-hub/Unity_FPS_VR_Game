using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class destroyoonpickup : MonoBehaviour
{
    public int whatsthis;
    void OnTriggerEnter (Collider other) {

        if(other.tag=="Bullet"){
            GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
            Destroy(gameObject);
            scripts.GetComponent<pickupcount>().available++;
        
        if(whatsthis==1)
        GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo = Math.Min(100,GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AmmoManager>()._9mmAmmo+30);
    	else GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<healthbar>().fill = Math.Min(1f,GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<healthbar>().fill+0.2f);

        }
}
}
