using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public Player player;
    private void Awake()
    {
        Instance = this;
    }
}
