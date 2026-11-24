using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class destroyonpickupammo : MonoBehaviour
{
    public AmmoManager bar;

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

        GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo = Math.Min(100,GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AmmoManager>()._9mmAmmo+30);
    }
}