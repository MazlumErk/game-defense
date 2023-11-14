using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float startDelay = 2f, spawnInterval = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnZombie", startDelay, spawnInterval);
    }


    private void SpawnZombie()
    {
        Instantiate(zombie, transform.position, transform.rotation, transform);
    }
}
