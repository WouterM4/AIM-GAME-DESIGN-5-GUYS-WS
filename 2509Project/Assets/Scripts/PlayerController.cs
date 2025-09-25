using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float maxHP = 3;
    public float currentHP;
    public int movementSpeed;
    public Camera playerCamera;
    private Vector2 mousePosition;
    private Vector3 desiredLocation;
    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        currentHP = maxHP;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.position != desiredLocation)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, desiredLocation, movementSpeed * Time.fixedDeltaTime));
        }
    }

    void OnMove()
    {
        Ray clickRay = playerCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(clickRay, out hit))
        {
            Debug.DrawLine(playerCamera.transform.position, hit.point, Color.orange, 1);
            desiredLocation = hit.point;
        }
    }

    void OnLook(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }
}
