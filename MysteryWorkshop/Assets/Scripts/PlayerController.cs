using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerController : MonoBehaviour
{
    public float health = 5;
    private Color originalColor;
    
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        
    }

    private void Start()
    {
        originalColor = _meshRenderer.material.color;
    }


    public void takeDamage(float damage)
    {
        StartCoroutine(FlashRed());
        health -= damage;
        Debug.Log(health);
        if( health <= 0) Destroy(gameObject);
    }
    
    private IEnumerator FlashRed()
    {
        _meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _meshRenderer.material.color = originalColor;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
