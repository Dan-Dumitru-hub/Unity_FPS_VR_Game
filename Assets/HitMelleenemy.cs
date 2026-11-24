using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMelleenemy : MonoBehaviour
{
    public GameObject enemy;
    public MelleScript scr;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float defense;


    private void OnTriggerEnter(Collider other)
    {
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (other.tag == "Bullet")
        {
            // print(this.GetComponentInChildren<healthbar>().fill);
            if (this.GetComponentInChildren<healthbar>() && other.gameObject.GetComponent<damageCheck>())
            {
                this.GetComponentInChildren<healthbar>().fill -= other.gameObject.GetComponent<damageCheck>().damage/defense;
                audioSource.PlayOneShot(audioClip,0.3f);

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