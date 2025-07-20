using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;

    private void Start()
    {
        Instantiate(chunkPrefab, transform.position, Quaternion.identity);
    }
    
}
