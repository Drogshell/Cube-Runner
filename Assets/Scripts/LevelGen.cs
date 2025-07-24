using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int startingChunkSize = 12;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private float chunkLength = 10f;
    [SerializeField] private float moveSpeed = 2f;

    private List<GameObject> _chunks = new();
    
    private void Start()
    {
        SpawnInitialChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void SpawnInitialChunks()
    {
        for (var i = 0; i < startingChunkSize; i++)
        {
            SpawnSingleChunk();
        }
    }

    private void SpawnSingleChunk()
    {
        var spawnPositionZ = CalculateSpawnPoint();
        
        var chunkSpawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        var chunk = Instantiate(chunkPrefab, chunkSpawnPosition, Quaternion.identity, chunkParent);
            
        _chunks.Add(chunk);
    }

    private float CalculateSpawnPoint()
    {
        float spawnPositionZ;

        if (_chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            // Get the specific transform of the last element in the list
            spawnPositionZ = _chunks[^1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    private void MoveChunks()
    {
        for (var i = 0; i < _chunks.Count; i++)
        {
            // Grab the chunk and move it backwards
            var chunk = _chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
            
            // If the chunk moves behind the player delete it
            if (chunk.transform.position.z < Camera.main.transform.position.z - chunkLength)
            {
                DestroyChunks(chunk);
            }
            
        }
        
    }

    private void DestroyChunks(GameObject chunk)
    {
        _chunks.Remove(chunk);
        Destroy(chunk);
        SpawnSingleChunk();
    }
    
}
