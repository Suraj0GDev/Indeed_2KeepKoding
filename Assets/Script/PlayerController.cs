using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement and jump settings
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;
    public float jumpForce = 5f;

    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 moveDirection; // Stores the player's movement direction
    private float verticalVelocity; // Controls vertical movement (e.g., jumping, falling)
    private float gravity = 9.81f; // Gravity constant for the game

    public Transform cameraTransform; // Assign the Cinemachine Virtual Camera's Transform here

    private void Start()
    {
        // Initialize the CharacterController and lock the cursor for better control
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Handle player movement, rotation, and grounding checks
        Move();
        RotatePlayer();
        IsGrounded();
    }

    private void Move()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal"); // Horizontal movement (A/D or arrow keys)
        float moveZ = Input.GetAxis("Vertical");   // Vertical movement (W/S or arrow keys)

        // Calculate movement direction based on player orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Check if the player is grounded
        if (IsGrounded())
        {
            Debug.Log("grounded");
            verticalVelocity = -gravity * Time.deltaTime; // Apply small gravity to keep grounded

            // Jump when the player presses the Jump button
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            // Apply gravity when the player is not grounded
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Combine horizontal and vertical movement
        moveDirection = move * moveSpeed;
        moveDirection.y = verticalVelocity;

        // Apply movement to the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        // Get mouse input for player rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Rotate the player on the Y axis (left and right)
        transform.Rotate(Vector3.up * mouseX);
    }

    private bool IsGrounded()
    {
        // Raycast to check if the player is grounded
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.1f);
    }
}
