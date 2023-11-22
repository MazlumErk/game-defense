using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance;
    // UI
    [SerializeField] private TextMeshProUGUI ammoText, rifleModeText, healthText;

    private void Awake()
    {
        Instance = this;
    }

    public void UiUpdate()
    {
        rifleModeText.text = $"{GetRifle().data.rifleMode}";
        ammoText.text = $"Mermi: {GetRifle().data.ammo}" ;
        healthText.text = $"Can: {GetPlayer().health}";
    }

    private Rifle GetRifle()
    {
        return RifleManager.Instance.rifle;
    }

    private Player GetPlayer()
    {
        return PlayerManager.Instance.player;
    }
}