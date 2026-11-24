using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level0physics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter (Collider other) {
        if(other.tag=="Bullet"){
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Scripts").GetComponentInChildren<gameeventforest>().GameStart();
}}
}
