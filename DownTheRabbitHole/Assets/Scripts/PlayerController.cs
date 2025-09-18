using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 100;
    public float rotationSpeed = 100;
    private Rigidbody rb;
    private float movement;
    private Vector3 rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementSpeed * Time.deltaTime * movement * transform.forward);
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rotationSpeed * Time.deltaTime * rotation));
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = movementVector.y;
        rotation = new Vector3(0, movementVector.x, 0);
    }
}