using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerHeightModifier : MonoBehaviour
{

    private CharacterController controller;
    public GameObject vrCamera;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.height = vrCamera.transform.position.y - transform.position.y;
        controller.stepOffset = (vrCamera.transform.position.y - transform.position.y) * 0.66f;
    }
}
