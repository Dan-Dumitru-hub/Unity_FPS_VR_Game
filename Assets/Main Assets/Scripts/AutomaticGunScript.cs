using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AutomaticGunScript : MonoBehaviour
{
    public float speed = 80;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private float FireRate = 10;
    private Animator _animator;
    private Coroutine _current;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void StartFire()
    {
      /*  if (_current != null)
        {
            StopCoroutine(_current);
            _animator.Play("Idle");
        }*/

        _animator.Play("Shoot");
        _current = StartCoroutine(Fire());
    }

    public void StopFire()
    {
        if (_current != null)
        {
            StopCoroutine(_current);
            _animator.Play("Idle");

        }
        
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 5);
            yield return new WaitForSeconds(1f / FireRate);
        }
    }
}
