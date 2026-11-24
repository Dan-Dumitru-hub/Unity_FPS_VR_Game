using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{

    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;

    private void Start()
    {
        for (int j = 0; j < objectsToRotate.Length; j++)
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, 50 * Time.deltaTime, 0) + objectsToRotate[j].localRotation.eulerAngles);
        }

        Invoke("invokeBuild",0.5f);
    } 

    void invokeBuild()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }        
    }

    // Use this for initialization
    void Update()
    {
    }

    private void FixedUpdate()
    { 
         //StartCoroutine(RoutineBaker());
    }

    private IEnumerator RoutineBaker()
    {
        for (int j = 0; j < objectsToRotate.Length; j++)
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, 50 * Time.deltaTime, 0) + objectsToRotate[j].localRotation.eulerAngles);
        }

        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }

        yield return new WaitForSeconds(5f);
    }

}