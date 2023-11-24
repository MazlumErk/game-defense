using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    public static ZombieAnimationController Instance;
    private void Start()
    {
        Instance = this;
        RunAnimation();
    }

    public void RunAnimation()
    {
        gameObject.GetComponent<Animation>().Play("Run");
    }

    public void AttackAnimation()
    {
        gameObject.GetComponent<Animation>().Play("Attack1");
    }
}
