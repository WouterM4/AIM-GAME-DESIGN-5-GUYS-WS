using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpKey : MonoBehaviour
{
    public bool hasKey = false;
    [SerializeField] private GameObject keyHolder;
    [SerializeField] private GameObject key;

    private GameObject _heldKeyInstance;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Key")) return;
        if (hasKey) return;
        
        hasKey = true;
        _heldKeyInstance = Instantiate(key, keyHolder.transform);
        _heldKeyInstance.transform.localPosition = Vector3.zero;
        _heldKeyInstance.transform.localRotation = Quaternion.identity;
        
        Destroy(other.gameObject);
    }
    
    public void OnAttack()
    {
        if (hasKey && _heldKeyInstance != null)
        {
            hasKey = false;
            Vector3 dropPosition = transform.position + transform.forward * 1.5f;
            Quaternion dropRotation = Quaternion.identity;

            Instantiate(key, dropPosition, dropRotation);
            
            Destroy(_heldKeyInstance);
            _heldKeyInstance = null;
        }
    }
}
