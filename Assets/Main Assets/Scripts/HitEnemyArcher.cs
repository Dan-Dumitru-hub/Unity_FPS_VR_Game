using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyArcher : MonoBehaviour
{
    public GameObject enemy;
    public EnemyAiTutorial scr;
    public AudioSource audioSource;
    public AudioClip audioClip;


    private void OnTriggerEnter(Collider other)
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (other.tag == "Bullet")
        {
            // print(this.GetComponentInChildren<healthbar>().fill);
            if (this.GetComponentInChildren<healthbar>() && other.gameObject.GetComponent<damageCheck>())
            {
                this.GetComponentInChildren<healthbar>().fill -= other.gameObject.GetComponent<damageCheck>().damage;
                audioSource.PlayOneShot(audioClip, 0.3f);
                if (other.gameObject)
                {
                    Destroy(other.gameObject);
                    if (GetComponentInChildren<healthbar>().fill <= 0)
                    {
                        this.scr.dead = true;
                    }
                }
                
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
