using UnityEngine;
using UnityEngine.InputSystem;


public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 100;
    [SerializeField] private int accelerationSpeed = 1;
    [SerializeField] private int turnSpeed = 10;
    [SerializeField] private float torqueStrength = 10;

    private float horizontalRotation;
    private float verticalRotation;
    private float forwardMovementSpeed;
    private Rigidbody rb;
    private Vector2 currentInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero; // or a custom local offset
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * forwardMovementSpeed * Time.deltaTime);
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(verticalRotation, horizontalRotation, 0) * turnSpeed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        
        //rotation
        Vector3 torque = new Vector3(-currentInput.y, currentInput.x, 0f) * torqueStrength;
        rb.AddRelativeTorque(torque, ForceMode.Impulse);
    }

    public void OnMove(InputValue movementValue)
    {
        currentInput = movementValue.Get<Vector2>();
    }

    void OnBoost()
    {
        forwardMovementSpeed = Mathf.Min(forwardMovementSpeed + accelerationSpeed, maxSpeed);
    }
}