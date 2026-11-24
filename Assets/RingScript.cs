using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingScript : MonoBehaviour
{
    public int ringsCollected;
    private int ringsTotal;
    // Start is called before the first frame update
    void Start()
    {
        ringsCollected = 0;
        ringsTotal = gameObject.GetComponentInChildren<Transform>().childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (ringsCollected == ringsTotal)
        {
            PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(4);
        }
    }
}
