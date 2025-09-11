using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private MeteorController meteorPrefab;
    [SerializeField] private PoolManager<MeteorController> poolManager;
    [SerializeField] private float spawnCooldown = 1;
    [SerializeField] private float maxSpawnTime = 5;
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 15f;
    //CHATGPT VARIABLE
    [SerializeField] private Vector3 spawnAreaCenterOffset = Vector3.zero;
    private Coroutine spawnCoroutine;
    
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnMeteors());
    }

    private IEnumerator SpawnMeteors()
    {
        while (true)
        {
            MeteorController meteor = poolManager.RequestObject();

            Vector3 spawnPosition = GetRandomSpawnPosition();
            
            meteor.transform.position = spawnPosition;
            
            meteor.Initialize((spawnPosition - transform.position).normalized);
            
            yield return new WaitForSeconds(Random.Range(spawnCooldown, maxSpawnTime));
        }
    }
    
    
    //CHATGPT HEEFT DIT GEDAAN IK HAD GEEN TIJD
    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 center = transform.position + spawnAreaCenterOffset;

        // Pick a random point on the surface of a unit sphere (normalized direction)
        Vector3 randomDirection = Random.onUnitSphere;

        // Pick a random distance between min and max
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Final spawn position = center + direction * distance
        Vector3 spawnPosition = center + randomDirection * randomDistance;

        return spawnPosition;
    }
}
