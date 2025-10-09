using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private Vector2 currentMovementInput;
    private Vector3 velocity;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Only run this code on the object the local client owns.
        // This prevents us from moving other players' objects.
        if (!IsOwner)
            return;
        Move();
    }

    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }     
        
        Vector3 move = new Vector3(currentMovementInput.x, 0, currentMovementInput.y);
        move = Vector3.ClampMagnitude(move, 1f);
        characterController.Move(move * Time.deltaTime * moveSpeed);
        
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        //apply gravity
        velocity.y += gravityValue * Time.deltaTime;
        Vector3 finalMove = (move * moveSpeed) + (velocity.y * Vector3.up);
        characterController.Move(finalMove * Time.deltaTime);
        
    }

    public override void OnStartClient()
    {
        if (IsOwner)
            GetComponent<PlayerInput>().enabled = true;
    }

    public void OnMove(InputValue value)
    {
        currentMovementInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        Jump();
    }

    private void Jump()
    {
        if (characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
    }


    
    
}
