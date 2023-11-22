using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance;

    public Zombie zombie;
    private void Awake()
    {
        Instance = this;
    }
}
