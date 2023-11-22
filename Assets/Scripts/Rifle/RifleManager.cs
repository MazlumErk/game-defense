using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleManager : MonoBehaviour
{
    public static RifleManager Instance;
    public Rifle rifle;

    public void Awake()
    {
        Instance = this;
    }
}
