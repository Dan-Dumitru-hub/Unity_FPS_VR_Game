using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public XRNode inputSource;
    private bool isSprinting = false;
    private float initialSpeed;
    private bool isExhausted = false;

    private void Start()
    {
        initialSpeed = GetComponent<DeviceBasedContinuousMoveProvider>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out isSprinting);

        if (GetComponentInChildren<sprintbar>().fill > 0f && !isExhausted)
        {
            if (isSprinting)
            {
                GetComponent<DeviceBasedContinuousMoveProvider>().moveSpeed = initialSpeed * 2;
                StartCoroutine(losingSprint());
            }
            else
            {
                GetComponent<DeviceBasedContinuousMoveProvider>().moveSpeed = initialSpeed;
                if (GetComponentInChildren<sprintbar>().fill < 1f)
                    StartCoroutine(regeneratingSprint());
            }
        }
        else if (!isExhausted)
        {
            StartCoroutine(exhaustedBehaviour());
        }

    }

    IEnumerator exhaustedBehaviour()
    {
        isExhausted = true;
        GetComponent<DeviceBasedContinuousMoveProvider>().moveSpeed = initialSpeed / 2;
        yield return new WaitForSeconds(1.5f);
        while (GetComponentInChildren<sprintbar>().fill < 0.5f)
        {
            StartCoroutine(regeneratingSprint());
            yield return new WaitForSeconds(0.01f);
        }
        isExhausted = false;
    }

    IEnumerator regeneratingSprint()
    {
        GetComponentInChildren<sprintbar>().fill += 0.01f;
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator losingSprint()
    {
        if (GetComponentInChildren<sprintbar>().fill > 0f)
            GetComponentInChildren<sprintbar>().fill -= 0.005f;
        yield return new WaitForSeconds(0.02f);
    }
}
