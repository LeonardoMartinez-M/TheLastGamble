using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float sprintSpeedMultiplier = 2.5f; // Adjust this to control the sprint speed
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private float rotationSpeed = 5f; // Adjust this value to control the rotation speed
    [SerializeField]
    private float gravityMultiplier = 1f; // Adjust this to control the strength of gravity

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    private bool isSprinting = false;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager._instance;
        cameraTransform = Camera.main.transform;

        inputManager.Sprinting.performed += SprintingOn;
        inputManager.Sprinting.canceled += SprintingOff;

    }
    
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        float currentSpeed = playerSpeed;
        if (isSprinting)
        {
            currentSpeed *= sprintSpeedMultiplier;
        }
        
        if (move != Vector3.zero)
        {
            // Calculate the target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(move);

            // Smoothly rotate the player towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // Makes the player jump
        if (inputManager.PlayerJumpedThisFrame())
        {
            // Calculate the initial vertical velocity required to reach the desired jump height
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue * gravityMultiplier);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * gravityMultiplier * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void SprintingOn(InputAction.CallbackContext obj)
    {
        isSprinting = true;

    }
    private void SprintingOff(InputAction.CallbackContext obj)
    {
        isSprinting = false;
    }
    
}