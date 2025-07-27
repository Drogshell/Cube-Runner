using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{   
    [SerializeField] private List<GameObject> pickupPrefabs;
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private float[] lanes;
    private List<int> _availableLanes = new() { 0, 1, 2 };

    private void Start()
    {
        SpawnFence();
        SpawnPickups();
    }

    private void SpawnFence()
    {
        if (_availableLanes.Count <= 0) return;
        var fencesToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < fencesToSpawn; i++)
        {
            var selectedLane = SelectLane();
            var spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }
    
    private void SpawnPickups()
    {
        var prefab = pickupPrefabs[Random.Range(0, pickupPrefabs.Count)];
        var pickupComponent = prefab.GetComponent<Pickup>();

        if (Random.value >= pickupComponent.spawnChance || _availableLanes.Count <= 0) return;
        
        var pickUpsToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < pickUpsToSpawn; i++)
        {
            var selectedLane = SelectLane();
            var spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(prefab, spawnPos, Quaternion.identity, this.transform);
        }
    }
    
    private int SelectLane()
    {
        var randomLane = Random.Range(0, _availableLanes.Count);
        var selectedLane = _availableLanes[randomLane];
        _availableLanes.Remove(selectedLane);
        return selectedLane;
    }
}
