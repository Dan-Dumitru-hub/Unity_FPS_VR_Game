using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Vector3 CheckpointPos;
    // Start is called before the first frame update
    void Start()
    {
        CheckpointPos = GetComponent<Transform>().position;
    }

}
