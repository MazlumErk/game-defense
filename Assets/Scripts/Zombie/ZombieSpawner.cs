using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float startDelay = 2f, spawnInterval = 1.5f;
    [SerializeField] private GameObject[] zombieSpawnLocations;
    void Start()
    {
        InvokeRepeating("SpawnZombie", startDelay, spawnInterval);
    }


    private void SpawnZombie()
    {
        int selectedZombieSpawner = Random.Range(0, zombieSpawnLocations.Length);
        Instantiate(zombie, zombieSpawnLocations[selectedZombieSpawner].transform.position, zombieSpawnLocations[selectedZombieSpawner].transform.rotation, transform);
    }
}
