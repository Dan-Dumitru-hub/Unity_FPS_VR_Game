using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableJump : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().jumpHeight = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().forwardSpeed = 0;
    }
}
