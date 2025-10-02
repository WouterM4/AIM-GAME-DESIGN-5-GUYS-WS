using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent((typeof(PlayerMovement)))]
public class PlayerInputProcessor : MonoBehaviour
{
    [SerializeField] private CameraController playerCamera;
    [SerializeField] private float sensitivity;
    private Vector2 _currentMovementInput;
    private Vector2 _currentMouseDelta;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_currentMovementInput);
        _playerMovement.RotateHorizontally(_currentMouseDelta.x * sensitivity * Time.deltaTime);
        playerCamera.RotateVertically(_currentMouseDelta.y * sensitivity * Time.deltaTime);
    }
    
    public void OnMove(InputValue value)  
    {
        _currentMovementInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        _currentMouseDelta = value.Get<Vector2>();
    }
}
