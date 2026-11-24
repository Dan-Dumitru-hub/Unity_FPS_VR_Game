using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitflyingexl : MonoBehaviour
{
    public GameObject enemy;
    public flyingaiturorialexplosive scr;



    private void OnTriggerEnter(Collider other)
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (other.tag == "Bullet")
        {
            // print(this.GetComponentInChildren<healthbar>().fill);
            this.GetComponentInChildren<healthbar>().fill -= other.gameObject.GetComponent<damageCheck>().damage;
            Destroy(other.gameObject);
           
                this.scr.dead = true;
            
        }
    }

    public void DestroyObject()
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        Destroy(enemy);
        //scripts.GetComponent<SpawnEnemy>().EnemyCount--;
    }
}
