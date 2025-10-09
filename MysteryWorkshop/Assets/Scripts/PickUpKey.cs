using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpKey : MonoBehaviour
{
    public bool hasKey = false;
    [SerializeField] private GameObject keyHolder;
    [SerializeField] private GameObject key;
    [SerializeField] private float throwForce = 15f;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Key")) return;
        if (hasKey) return;
        
        hasKey = true;
        pickupKey(other.gameObject);
    }
    
    public void OnPrevious()
    {
        if (hasKey)
        {
            hasKey = false;
            
            GameObject key = GameObject.FindWithTag("Key");
            Debug.Log(key);
            Vector3 dropPosition = transform.position + transform.forward * 1.5f;
            key.transform.SetParent(null, true);
            key.transform.localPosition = dropPosition;
        }
    }

    private void pickupKey(GameObject key)
    {
        key.transform.SetParent(transform);
        key.transform.localPosition = keyHolder.transform.localPosition;
    }
}
