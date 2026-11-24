using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void FirstLevelStart()
    {
        // SceneManager.UnloadSceneAsync(0);
        StartCoroutine("LoadFirstLevel");
    }

    public void SecondLevelStart()
    {
        // SceneManager.UnloadSceneAsync(0);
        StartCoroutine("LoadSecondLevel");
    }

    public void ThirdLevelStart()
    {
        // SceneManager.UnloadSceneAsync(0);
        StartCoroutine("LoadThirdLevel");
    }

    IEnumerator LoadFirstLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSecondLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadThirdLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(5);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
