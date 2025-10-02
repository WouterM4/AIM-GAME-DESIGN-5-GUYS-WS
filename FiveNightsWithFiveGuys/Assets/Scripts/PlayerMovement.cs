using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        var movement = new Vector3(input.x, 0, input.y);
        var movementVector = transform.TransformDirection(movement) * movementSpeed;
        movementVector.y = _rigidbody.linearVelocity.y;
        _rigidbody.linearVelocity = movementVector;
    }

    public void RotateHorizontally(float rotation)
    {
        transform.Rotate(Vector3.up, rotation);
    }
    
}
