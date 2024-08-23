using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;
    public float jumpForce = 5f; 

    private CharacterController controller;
    private Vector3 moveDirection;
    private float verticalVelocity;
    private float gravity = 9.81f;

   


    public Transform cameraTransform; // Assign the Cinemachine Virtual Camera's Transform here
    
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor for better control
    }

    private void Update()
    {
        Move();
        RotatePlayer();
        IsGrounded();
        
    }

    private void Move()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;



        // Check if the player is grounded
        if (IsGrounded())
        {
            Debug.Log("grounded");
            verticalVelocity = -gravity * Time.deltaTime; // Apply small gravity to keep grounded
            if (Input.GetButtonDown("Jump")) // Jump when the player presses the Jump button
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime; // Apply gravity when not grounded
        }


        moveDirection = move * moveSpeed;
        moveDirection.y = verticalVelocity;
        // Apply movement to the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        // Get the mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
       
        // Rotate the player on the Y axis (left and right)
        transform.Rotate(Vector3.up * mouseX);


        

    }

    private bool IsGrounded()
    {
        // Raycast to the ground
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.1f);
    }
}
