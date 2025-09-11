using UnityEngine;
using UnityEngine.InputSystem;


public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 100;
    [SerializeField] private int accelerationSpeed = 1;
    [SerializeField] private int turnSpeed = 10;

    private float horizontalRotation;
    private float verticalRotation;
    private float forwardMovementSpeed;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward *    forwardMovementSpeed * Time.deltaTime);
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(verticalRotation, horizontalRotation, 0) * turnSpeed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movemementVector = movementValue.Get<Vector2>();
        horizontalRotation = movemementVector.x;
        verticalRotation = movemementVector.y;
    }

    void OnBoost()
    {
        forwardMovementSpeed = Mathf.Min(forwardMovementSpeed + accelerationSpeed, maxSpeed);
    }
}
