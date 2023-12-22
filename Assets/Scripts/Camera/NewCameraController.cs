using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float CameraSensitivity;
    void Start()
    {
        transform.position = player.transform.position;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * CameraSensitivity);
    }
}
