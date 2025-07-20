using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int startingChunkSize = 12;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private float chunkLength = 10f;
    
    private void Start()
    {
        for (int i = 0; i < startingChunkSize; i++)
        {
            var spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + chunkLength * i);
            Instantiate(chunkPrefab, spawnPosition, Quaternion.identity, chunkParent);
        }
    }
    
}
