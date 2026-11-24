using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonpickupcolectible : MonoBehaviour
{
  

    public void destroy(){

        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        Destroy(gameObject);
        scripts.GetComponent<gameEvent>().collectiblesGotten += 1;
        
    }
}