using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorController : PoolObject<MeteorController>
{
    [SerializeField] private float displayTime = 5;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2f;
    [SerializeField] private float minSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 2f;
    private float _speed;
    private Coroutine _disableCoroutine;
    private Rigidbody _rigidbody;
    private Vector3 playerDirection;
    
    void Start()
    {
        InvokeDespawnAfterDelay();
    }

    public void Initialize(Vector3 playerDirection)
    {
        float scale = Random.Range(minScale, maxScale);
        transform.localScale = Vector3.one * scale;
        
        _speed = Random.Range(minSpeed, maxSpeed);
        
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(playerDirection * _speed);
    }

    private void InvokeDespawnAfterDelay()
    {
        if (_disableCoroutine != null)
            StopCoroutine(_disableCoroutine);

        _disableCoroutine = StartCoroutine(DisableAfterDelay(displayTime));
    }
    
    private IEnumerator DisableAfterDelay(float displayTime)
    {
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
        ReturnToPool();
    }
}
