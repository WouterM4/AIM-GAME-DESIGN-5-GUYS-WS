using System.Collections.Generic;
using UnityEngine;

public class PoolManager<T> : MonoBehaviour where T : PoolObject<T>
{
    [SerializeField] private T prefab;
    private readonly Queue<T> _pool = new();
    
    private void CreateNewObject()
    {
        var obj = Instantiate(prefab, transform);
        obj.InitPoolObject(this);
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
    
    public T RequestObject()
    {
        if (_pool.Count == 0)
        {
            CreateNewObject();
        }
        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}