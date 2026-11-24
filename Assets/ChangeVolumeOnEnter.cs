using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolumeOnEnter : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainHouse")
        {
            audioSource.volume = 0.05f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainHouse")
        {
            audioSource.volume = 0.1f;
        }
    }
}
