using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float obstacleSpawnTime;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private float spawnWidth;


    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            var obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            var spawnPos = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            
            yield return new WaitForSeconds(obstacleSpawnTime);
            
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstacleParent);
        }
    }
    
}
