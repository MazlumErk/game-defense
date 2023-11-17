using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RifleShot : MonoBehaviour
{
    [SerializeField] private GameObject kup;
    [SerializeField] private AudioSource rifleShoutSound;
    private Vector3 cizgiSon;
    // Silah modu
    [SerializeField] private bool RifleMode;
    // Silah hızı
    [SerializeField] private float fireRate = 0.2f, currentRate;
    // Silah particle
    [SerializeField] private ParticleSystem rifleParticle;

    // UI
    [SerializeField] private Text ammoText, rifleModeText;
    [SerializeField] private int ammo;

    private void Start()
    {
        currentRate = fireRate;
        rifleModeText.text = RifleMode == true ?  "-" : "---";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && ammo > 0)
        {
            currentRate += Time.deltaTime;
            if (currentRate >= fireRate)
            {
                ammo--;
                ammoText.text = "Mermi: " + ammo.ToString();
                // Fare pozisyonu
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Işın
                RaycastHit hitInfo;

                // Işın bir objeye çarptıysa
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // // Işın başlangıç noktası
                    // Debug.Log("Işın Başlangıç Noktası: " + ray.origin);
                    // // Işın bitiş noktası
                    // Debug.Log("Işın Bitiş Noktası: " + hitInfo.point);
                    // // Işının çarptığı obje
                    // Debug.Log("Işın çarptı: " + hitInfo.collider.gameObject.name);


                    // Line oluştur, line başlangıç ve bitiş kordinatlarını ayarla
                    cizgiSon = hitInfo.point;
                    if (!hitInfo.collider.GetComponent<CubeController>())
                    {
                        Instantiate(kup, cizgiSon, Quaternion.identity);
                    }
                    if (hitInfo.collider.tag == "Zombie")
                    {
                        Destroy(hitInfo.collider.gameObject);
                    }
                    rifleShoutSound.Play();
                    rifleParticle.Play();
                }
                currentRate = 0;
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentRate = 1;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 30;
            ammoText.text = "Mermi: " + ammo.ToString();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (RifleMode)
            {
                fireRate = 0.1f;
            }
            else
            {
                fireRate = 1;
            }
            RifleMode = !RifleMode;
            rifleModeText.text = RifleMode == true ?  "-" : "---";
        }
    }
}
