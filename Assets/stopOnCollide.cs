using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopOnCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.4f;
    }
}
