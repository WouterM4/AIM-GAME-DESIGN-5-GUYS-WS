using UnityEngine;

public abstract class PoolObject<T> : MonoBehaviour where T : PoolObject<T>
{
    private PoolManager<T> _poolManager;

    public void InitPoolObject(PoolManager<T> poolManager)
    {
        _poolManager = poolManager;
    }

    protected void ReturnToPool()
    {
        _poolManager.ReturnToPool((T)this);
    }
}