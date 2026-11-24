using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private Vector3 lastCheckpoint;
    private void Start()
    {
        lastCheckpoint = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        // print(lastCheckpoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathCollider")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = lastCheckpoint;
            // print(lastCheckpoint);
            GetComponentInChildren<healthbar>().fill = Math.Max(GetComponentInChildren<healthbar>().fill - 0.2f, 0f);
            if (GetComponentInChildren<healthbar>().fill <= 0f)
            {
                PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadSceneAsync(3);
            }
            // print("Out of bounds");
        }
        else if (other.tag == "Checkpoint")
        {
            lastCheckpoint = other.GetComponent<CheckpointScript>().CheckpointPos;
            Destroy(other.gameObject);
            print("Set Checkpoint");
        }
    }
}
