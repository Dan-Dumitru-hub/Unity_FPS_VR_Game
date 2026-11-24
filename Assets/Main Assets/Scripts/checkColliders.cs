using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkColliders : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Plane" || other.tag == "Player" || other.tag == "VRCamera")
            Destroy(gameObject);
}

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
