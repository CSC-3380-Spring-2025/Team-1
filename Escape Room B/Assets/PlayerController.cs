using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // how fast the player moves
    public float acceleration = 10f; // how smooth movement feels
    public float mouseSensitivity = 2f; // mouse look speed
    public float gravity = -9.81f; // gravity pull
    public Transform cameraTransform; // the player's camera

    private CharacterController controller;
    private Vector3 velocity; // used for gravity
    private Vector3 currentMoveVelocity; // smooth movement
    private Vector3 moveInput; // raw input
    private float xRotation = 0f; // camera up/down rotation

    void Start()
    {
        controller = GetComponent<CharacterController>(); // get the character controller
        Cursor.lockState = CursorLockMode.Locked; // lock the mouse to the screen
        Cursor.visible = false; // hide the mouse
    }

    void Update()
    {
        HandleMouseLook(); // rotate player and camera
        HandleMovement(); // move the player
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // stop camera from flipping

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // up/down
        transform.Rotate(Vector3.up * mouseX); // left/right
    }

    void HandleMovement()
    {
        // reset gravity when grounded
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // apply gravity
        velocity.y += gravity * Time.deltaTime;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // get direction based on player orientation
        moveInput = (transform.right * moveX + transform.forward * moveZ).normalized;

        // smooth acceleration
        currentMoveVelocity = Vector3.Lerp(currentMoveVelocity, moveInput * moveSpeed, acceleration * Time.deltaTime);

        // final movement vector with gravity
        Vector3 finalMove = currentMoveVelocity + new Vector3(0f, velocity.y, 0f);

        // move the character
        controller.Move(finalMove * Time.deltaTime);
    }
}