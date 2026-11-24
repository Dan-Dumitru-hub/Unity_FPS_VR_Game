using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class destroyonpickup : MonoBehaviour
{
    public healthbar bar;

    public void destroyAfterTime()
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (gameObject)
        {
            Destroy(gameObject);
            scripts.GetComponent<pickupcount>().available++;
        }
    }

    public void destroy(){

        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        // bar.fill+=20;
        Destroy(gameObject);
        scripts.GetComponent<pickupcount>().available++;

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<healthbar>().fill = Math.Min(1f,GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<healthbar>().fill+0.2f);
        
    }
}