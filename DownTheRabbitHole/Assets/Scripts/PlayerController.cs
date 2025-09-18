using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 100;
    public float rotationSpeed = 100;
    public Camera playerCamera;
    private Vector3 cameraOffset;
    private Rigidbody rb;
    private float movement;
    private Vector3 rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraOffset = playerCamera.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementSpeed * Time.deltaTime * movement * playerCamera.transform.forward);
        playerCamera.transform.LookAt(transform);
        playerCamera.transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime * rotation.y);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = movementVector.y;
        rotation = new Vector3(0, movementVector.x, 0);
    }
}