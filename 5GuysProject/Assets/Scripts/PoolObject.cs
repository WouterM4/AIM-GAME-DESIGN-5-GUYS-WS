using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    protected PoolManager _poolManager;

    public void InitPoolObject(PoolManager poolManager)
    {
        _poolManager = poolManager;
    }
}