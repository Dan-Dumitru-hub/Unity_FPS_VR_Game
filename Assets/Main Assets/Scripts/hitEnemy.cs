using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (other.tag == "Bullet")
        {
            // print(this.GetComponentInChildren<healthbar>().fill);
            this.GetComponentInChildren<healthbar>().fill -= other.gameObject.GetComponent<damageCheck>().damage;
            Destroy(other.gameObject);
            if (this.GetComponentInChildren<healthbar>().fill <= 0)
            {
                Destroy(enemy);
                scripts.GetComponent<SpawnEnemy>().EnemyCount--;
            }
        }
    }
}
