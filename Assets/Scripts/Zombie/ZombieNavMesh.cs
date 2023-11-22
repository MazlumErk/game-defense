using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent zombie;
    // [SerializeField] private Transform player;
    [SerializeField] private Vector3 playerPosition;
    
    void Start()
    {
        playerPosition = Camera.main.transform.position;
    }

    void Update()
    {
        zombie.SetDestination(playerPosition);
    }
}
