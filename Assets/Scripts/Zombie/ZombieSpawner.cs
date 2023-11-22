using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float startDelay = 2f, spawnInterval = 1.5f;
    [SerializeField] private List<GameObject> zombieSpawnLocations;
    [SerializeField] private int zombieCount;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            zombieSpawnLocations.Add(transform.GetChild(i).gameObject);
        }
        InvokeRepeating("SpawnZombie", startDelay, spawnInterval);
    }


    private void SpawnZombie()
    {
        int selectedZombieSpawner = Random.Range(0, zombieSpawnLocations.Count);
        Instantiate(zombie, zombieSpawnLocations[selectedZombieSpawner].transform.position, zombieSpawnLocations[selectedZombieSpawner].transform.rotation, transform);

        zombieCount++;
    }
}
