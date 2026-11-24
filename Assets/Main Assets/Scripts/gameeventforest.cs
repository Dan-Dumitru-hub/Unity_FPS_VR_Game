using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameeventforest : MonoBehaviour
{

    private float coolDownTimer = 600f;
    
    private bool gameStart = false;
    //public GameObject door;

    public void GameStart()
    {
        gameStart = true;
        GetComponents<SpawnEnemy>()[0].enabled = true;
        GetComponents<SpawnEnemy>()[1].enabled = true;
        //door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var currentTime = (int)coolDownTimer;
        
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Text>())
        {
            if (currentTime % 60 > 9)
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Text>().text = "Time Left : " +
                       currentTime / 60 + ":" + currentTime % 60 + "\nObjectives : Survive " ;
           else
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Text>().text = "Time Left : " +
                       currentTime / 60 + ":0" + currentTime % 60 + "\nObjectives : Survive " ;
        }
            
        if (gameStart)
        {
            if (coolDownTimer > 0)
            {
                coolDownTimer = Math.Max(0f,coolDownTimer - Time.deltaTime);
               
            }
            else
            {
             PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
               SceneManager.LoadSceneAsync(4);
            }
        }
    }

}
