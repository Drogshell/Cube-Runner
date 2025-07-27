using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] public float spawnChance;

    public abstract void OnPickup();
}
