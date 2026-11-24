using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GunScript : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public GameObject explosion;
    public Transform explosionPos;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip noBulletFire;
    public AudioClip reloadSound;
    private Animator _animator;
    public int crtAmmo;
    public GameObject triggerCollider;
    public Transform shellPos;
    public GameObject shell;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        crtAmmo = 15;
        triggerCollider.GetComponent<MeshCollider>().isTrigger = false;
    }

    public void onPickup()
    {
        GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
        GetComponent<Outline>().enabled = false;
        triggerCollider.GetComponent<MeshCollider>().isTrigger = true;
    }

    public void onDrop()
    {
        GetComponentInChildren<Text>().text = "";
        GetComponent<Outline>().enabled = true;
        triggerCollider.GetComponent<MeshCollider>().isTrigger = false;
    }
    public void Fire()
    {
        if (crtAmmo > 0)
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position, Quaternion.LookRotation(barrel.forward));
            crtAmmo--;
            GameObject spawnedExplosion = Instantiate(explosion, explosionPos.position, Quaternion.LookRotation(explosionPos.forward));
            GameObject spawnedShell = Instantiate(shell, shellPos.position, Quaternion.LookRotation(shellPos.forward));
            spawnedShell.GetComponent<Rigidbody>().velocity = speed * 0.1f * shellPos.forward;
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            audioSource.PlayOneShot(audioClip,0.80f);
            _animator.SetTrigger("Shoot");
            Destroy(spawnedBullet, 5f);
            Destroy(spawnedShell, 5f);
            Destroy(spawnedExplosion, 0.2f);
           
        }
        else
        {
            audioSource.PlayOneShot(noBulletFire);
        }
        GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
    }

    private void Update()
    {
        GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
    }

    public void Reload()
    {
        if (crtAmmo > 0 && crtAmmo <= 14)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo > 15)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo -= (16 - crtAmmo);
                crtAmmo = 16;
                GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
                audioSource.PlayOneShot(reloadSound);
                return;
            }
            else
            {
                int minimumAmmo = Math.Min(16 - crtAmmo, GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo);
                crtAmmo += minimumAmmo;
                GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo -= minimumAmmo;
                GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
                audioSource.PlayOneShot(reloadSound);
                return;
            }
        }
        else if (crtAmmo == 0)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo > 15)
            {
                crtAmmo = 15;
                GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo -= 15;
                GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
                audioSource.PlayOneShot(reloadSound);
                return;
            }
            else
            {
                crtAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
                GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo = 0;
                GetComponentInChildren<Text>().text = crtAmmo + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>()._9mmAmmo;
                audioSource.PlayOneShot(reloadSound);
                return;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reload")
        {
            Reload();
        }
    }

}
