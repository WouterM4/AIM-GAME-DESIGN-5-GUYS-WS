using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private MeteorController prefab;
    private readonly Queue<MeteorController> _pool = new();
    
    private void CreateNewObject()
    {
        var obj = Instantiate(prefab);
        obj.InitPoolObject(this);
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
    
    public MeteorController RequestObject()
    {
        if (_pool.Count == 0)
        {
            CreateNewObject();
        }
        var obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnToPool(MeteorController obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}