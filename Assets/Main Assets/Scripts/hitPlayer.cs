using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hitPlayer : MonoBehaviour
{   
    public PlayerMovement scr;
    public AudioSource audioSource;
    public AudioClip damageSound;

    private void OnTriggerEnter(Collider other)
    {
        //GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        if (other.tag == "Enemy" || other.tag == "Enemysbullet" || other.tag == "Bullet")
        {
            // print("hit");
            if (GetComponentInChildren<healthbar>() && other.gameObject.GetComponent<damageCheck>())
            {
                this.GetComponentInChildren<healthbar>().fill -= other.gameObject.GetComponent<damageCheck>().damage;
                audioSource.PlayOneShot(damageSound, 1f);
            }
            // print(this.GetComponentInChildren<healthbar>().fill);
        }

        if (GetComponentInChildren<healthbar>().fill <= 0)
            {
                this.scr.dead=true;
                PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadSceneAsync(3);
        }
    }
}
