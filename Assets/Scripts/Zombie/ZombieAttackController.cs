using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttackController : MonoBehaviour
{
    public static ZombieAttackController Instance;
    [SerializeField] private GameObject playerLocation;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private float currentAttackSpeed;
    private void Awake()
    {
        Instance = this;
        playerLocation = FindObjectOfType<RifleShotController>().gameObject;
        currentAttackSpeed = 0.0f;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, playerLocation.transform.position) < playerNavMesh.stoppingDistance)
        {
            ZombieAnimationController.Instance.AttackAnimation();
            currentAttackSpeed += Time.deltaTime;
            if (currentAttackSpeed >= GetZombie().attackSpeed)
            {
                AttackToPlayer();
                GameUIController.Instance.UiUpdate();
                currentAttackSpeed = 0;
            }
        }
    }
    public void AttackToPlayer()
    {
        SetPlayerHealth(GetZombie().damage);
    }

    private Zombie GetZombie()
    {
        return ZombieManager.Instance.zombie;
    }

    private Player GetPlayer()
    {
        return PlayerManager.Instance.player;
    }

    private void SetPlayerHealth(int damage)
    {
        int newHealth = GetPlayer().health - damage;
        PlayerManager.Instance.player = new Player()
        {
            health = newHealth,
        };
    }
}
