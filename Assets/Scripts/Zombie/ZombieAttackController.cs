using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieAttackController : MonoBehaviour
{
    public static ZombieAttackController Instance;

    private void Awake()
    {
        Instance = this;
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
