using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class JumpingScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue;
    public XRNode inputSource;
    private bool isJumping;
    private Vector2 axisDirection;
   

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        gravityValue = Physics.gravity.y;
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primaryButton, out isJumping);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisDirection);

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(axisDirection.x, 0, axisDirection.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (isJumping && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}


 
