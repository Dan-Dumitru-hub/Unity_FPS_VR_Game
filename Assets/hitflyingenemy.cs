using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitflyingenemy : MonoBehaviour
{
    public GameObject enemy;
   public flyingaitutorial2 scr;




    private void OnTriggerEnter(Collider other)
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (other.tag == "Bullet")
        {
            // print(this.GetComponentInChildren<healthbar>().fill);
            this.GetComponentInChildren<healthbar>().fill -= other.gameObject.GetComponent<damageCheck>().damage;
            Destroy(other.gameObject);
            if (GetComponentInChildren<healthbar>().fill <= 0)
            {
                this.scr.dead=true;
            }
        }
    }

    public void DestroyObject()
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        Destroy(enemy);
        scripts.GetComponent<SpawnEnemy>().EnemyCount--;
    }
}
