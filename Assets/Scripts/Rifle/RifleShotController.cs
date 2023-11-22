using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;


public class RifleShotController : MonoBehaviour
{
    [SerializeField] private GameObject kup;
    [SerializeField] private AudioSource rifleShoutSound;
    [SerializeField] private float currentRate;
    // Silah particle
    [SerializeField] private ParticleSystem rifleParticle;



    
    private void Start()
    {
        currentRate = GetRifle().data.fireRate;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && GetRifle().data.ammo > 0)
        {
            currentRate += Time.deltaTime;
            if (currentRate >= GetRifle().data.fireRate)
            {

                // Fare pozisyonu
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // Işın
                RaycastHit hitInfo;

                // Işın bir objeye çarptıysa
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // // Işın başlangıç noktası
                    // ray.origin
                    // // Işın bitiş noktası
                    // hitInfo.point
                    // // Işının çarptığı obje
                    // hitInfo.collider.gameObject.name


                    if (!hitInfo.collider.GetComponent<CubeController>())
                    {
                        Instantiate(kup, hitInfo.point, Quaternion.identity);
                    }
                    if (hitInfo.collider.tag == "Zombie")
                    {
                        Destroy(hitInfo.collider.gameObject);
                    }
                    rifleShoutSound.Play();
                    rifleParticle.Play();
                    SetRifleData(GetRifle().data.ammo - 1);
                }
                currentRate = 0;
                // Debug.Log($"current: {GetRifle().data.ammo}, later: {GetRifle().data.ammo - 1}");
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentRate = 1;
        }

        RifleAmmoReload();
        RifleModeChanger();
    }


    // UI update


    // Rifle mode changer
    private void RifleModeChanger()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Debug.Log(!GetRifle().data.rifleMode);
            SetRifleData(newRifleMode: GetRifle().data.rifleMode == RifleMode.Auto ? RifleMode.SemiAuto : RifleMode.Auto);
            SetRifleData(newFireRate: GetRifle().data.rifleMode == RifleMode.Auto ? 0.1f : 1f);
            // UiUpdate();
        }
    }

    private void RifleAmmoReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetRifleData(30);
            // UiUpdate();
        }
    }

    private Rifle GetRifle()
    {
        return RifleManager.Instance.rifle;
    }

    private void SetRifleData(int? newAmmo = null, RifleMode? newRifleMode = null, float? newFireRate = null)
    {
        RifleManager.Instance.rifle.data = new RifleData()
        {
            ammo = newAmmo == null ? GetRifle().data.ammo : newAmmo.Value,
            rifleMode = newRifleMode == null ? GetRifle().data.rifleMode : newRifleMode.Value,
            fireRate = newFireRate == null ? GetRifle().data.fireRate : newFireRate.Value
        };
    }
}
