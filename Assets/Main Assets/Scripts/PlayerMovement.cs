using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    public XRNode inputSource;
    public bool dead = false;

    private CharacterController characterController;
    private bool slowMo;
    private bool canSlowMo;
    private float slowDownFloat = 0.6f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float jumpHeight;
    public float forwardSpeed;
    private bool jumpPressed = false;
    private float gravityValue;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        slowMo = false;
        jumpPressed = false;
        canSlowMo = true;
        gravityValue = Physics.gravity.y / 2;
    }

    IEnumerator DoSlowMotion()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = slowDownFloat;
            yield return new WaitForSeconds(1f);
        }
        else
        {
            Time.timeScale = 1f;
            yield return new WaitForSeconds(1f);
        }
    }

    private void FixedUpdate()
    {
        if (characterController != null)
            MovementJump();
    }

    void MovementJump()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer)
        {
            playerVelocity.x = 0;
            playerVelocity.y = 0;
            playerVelocity.z = 0;
        }

        if (jumpPressed && groundedPlayer)
        {
            playerVelocity.y += (float)Math.Sqrt(jumpHeight * -1.0f * gravityValue);
            playerVelocity += GameObject.FindGameObjectWithTag("VRCamera").GetComponent<Transform>().forward * forwardSpeed;
            jumpPressed = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void Update()
    {
        
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primaryButton, out jumpPressed);
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out slowMo);
        
        if (slowMo == true && canSlowMo == true)
        {
            canSlowMo = false;
            StartCoroutine("DoSlowMotion");
        }
        else if (slowMo == false && canSlowMo == false)
        {
            canSlowMo = true;
        }
    }
}