using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveArrows : MonoBehaviour
{

    public GameObject arrow;
    private GameObject[] arrows;
    private GameObject[] skulls;
    private bool arrowsAreSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnArrow", 3f);
    }
    
    void SpawnArrow()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        skulls = GameObject.FindGameObjectsWithTag("Skull");
        int i = 0;
        arrows = new GameObject[skulls.Length];

        foreach (GameObject skull in skulls)
        {
            arrows[i] = Instantiate(arrow,new Vector3(player.position.x, 0.1f, player.position.z), Quaternion.LookRotation(skull.transform.position));
            i++;
        }
        arrowsAreSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        skulls = GameObject.FindGameObjectsWithTag("Skull");
        if (arrowsAreSpawned)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            for (int i = 0; i < skulls.Length; i++)
            {
                if (skulls[i] != null)
                {
                    float dist = Vector3.Distance(skulls[i].transform.position, player.position);
                    if (dist < 1f)
                    {
                        Destroy(arrows[i].gameObject);
                        arrows[i] = null;
                    }

                    else
                    {
                        Vector3 difference = skulls[i].transform.position - player.position;
                        arrows[i].transform.rotation = Quaternion.LookRotation(difference.normalized);
                        arrows[i].transform.position = new Vector3(player.position.x, 0.1f, player.position.z);
                    }
                }
                else
                {
                    Destroy(arrows[i]);
                }
            }
        }
    }
}
