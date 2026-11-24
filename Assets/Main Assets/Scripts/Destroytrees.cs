using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroytrees : MonoBehaviour
{

    float timer = 2f;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Tree" || other.tag == "Cemetery Prefab")
        {
            Destroy(other.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else if (GetComponent<MeshCollider>().convex == true)
        {
            GetComponent<MeshCollider>().isTrigger = false;
            GetComponent<MeshCollider>().convex = false;
        }
    }
}
