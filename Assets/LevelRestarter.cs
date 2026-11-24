using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    public void RestartLevel()
    {
        // SceneManager.UnloadSceneAsync(0);
        StartCoroutine("RestartFirstLevel");
    }

    public void GoToMainMenu()
    {
        StartCoroutine("GoToMenu");
    }

    public void GoToNextLevel()
    {
        StartCoroutine("NextLevel");
    }

    IEnumerator RestartFirstLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator NextLevel()
    {
        int current_scene = PlayerPrefs.GetInt("SceneNumber");
        AsyncOperation asyncLoad = null;
        if (current_scene == 2)
            asyncLoad = SceneManager.LoadSceneAsync(1); // 2 = First level, 1 = Second level, 5 = Third level
        else if (current_scene == 1)
        {
            asyncLoad = SceneManager.LoadSceneAsync(5);
        }

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator GoToMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
