using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorController : PoolObject
{
    [SerializeField] private float displayTime = 20;
    [SerializeField] private float minScale = 1;
    [SerializeField] private float maxScale = 4;
    [SerializeField] private float minSpeed = 1000;
    [SerializeField] private float maxSpeed = 1500;
    private float _speed;
    private Coroutine _disableCoroutine;
    private Rigidbody _rigidbody;
    private Vector3 playerDirection;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeDespawnAfterDelay();
    }

    public void Initialize(Vector3 playerDir)
    {
        float scale = Random.Range(minScale, maxScale);
        transform.localScale = Vector3.one * scale;
        playerDirection = playerDir;
        
        _speed = Random.Range(minSpeed, maxSpeed);
        
    }

    void FixedUpdate()
    {
        _rigidbody.linearVelocity = transform.forward * _speed;
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
        _poolManager.ReturnToPool(this);
    }
}
