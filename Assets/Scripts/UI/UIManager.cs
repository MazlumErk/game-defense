using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Silah modu
    [SerializeField] private bool RifleMode;
    [SerializeField] private int ammo;

    // UI
    [SerializeField] private TextMeshProUGUI ammoText, rifleModeText;
    public void UiUpdate()
    {
        // rifleModeText.text = RifleMode == true ? "-" : "---";
        // ammoText.text = "Mermi: " + ammo.ToString();
    }
}
