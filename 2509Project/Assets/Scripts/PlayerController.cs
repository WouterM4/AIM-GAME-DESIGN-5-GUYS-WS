using System.Collections;
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
    private MeshRenderer _meshRenderer;
    private Color originalColor;
    
    void Start()
    { 
        currentHP = maxHP;
        rb = GetComponent<Rigidbody>();
        desiredLocation = new Vector3(transform.position.x, 1, transform.position.z);
        _meshRenderer = GetComponent<MeshRenderer>();
        originalColor = _meshRenderer.material.color;
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
            // Debug.DrawLine(playerCamera.transform.position, hit.point, Color.orange, 1);
            desiredLocation = hit.point;
        }
    }

    void OnLook(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        StartCoroutine(FlashRed());

        if (currentHP > 0f) return;
        Die();
    }

    private void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    private IEnumerator FlashRed()
    {
        _meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _meshRenderer.material.color = originalColor;
    }
}
