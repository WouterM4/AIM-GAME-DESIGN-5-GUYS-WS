using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Bouncepad : MonoBehaviour
{
    [SerializeField] private float power;
    
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody?.AddForce(Vector3.up * power, ForceMode.Impulse);
    }
}
