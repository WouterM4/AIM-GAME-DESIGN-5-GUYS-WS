using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpKey : MonoBehaviour
{
    public bool hasKey = false;
    [SerializeField] private GameObject keyHolder;
    [SerializeField] private GameObject key;
    [SerializeField] private float throwForce = 15f;

    private GameObject _heldKeyInstance;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Key")) return;
        if (hasKey) return;
        
        hasKey = true;
        _heldKeyInstance = Instantiate(key, keyHolder.transform);
        _heldKeyInstance.transform.localPosition = Vector3.zero;
        _heldKeyInstance.transform.localRotation = Quaternion.identity;
        
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    
    public void OnPrevious()
    {
        throwKey(0f);
    }

    public void OnNext()
    {
        throwKey(throwForce);
    }

    private void throwKey(float force)
    {
        if (hasKey && _heldKeyInstance != null)
        {
            hasKey = false;
            Vector3 dropPosition = transform.position + transform.forward * 1.5f;
            Quaternion dropRotation = Quaternion.identity;

            GameObject spawnedKey = Instantiate(key, dropPosition, dropRotation);
            
            spawnedKey.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            
            Destroy(_heldKeyInstance);
            _heldKeyInstance = null;
        }
    }
}
