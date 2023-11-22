using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private void Start()
    {
        GameUIController.Instance.UiUpdate();
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            GameUIController.Instance.UiUpdate();
        }
    }
}
