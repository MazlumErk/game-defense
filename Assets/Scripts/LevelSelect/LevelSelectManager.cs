using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private Material selectedCountry, unSelectedCountry;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Fare pozisyonu
            Ray rayy = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Işın
            RaycastHit hitInfoo;

            // Işın bir objeye çarptıysa
            if (Physics.Raycast(rayy, out hitInfoo))
            {
                // // Işın başlangıç noktası
                // ray.origin
                // // Işın bitiş noktası
                // hitInfo.point
                // // Işının çarptığı obje
                // hitInfo.collider.gameObject.name

                Debug.Log(hitInfoo.collider.gameObject.name);
                hitInfoo.collider.gameObject.GetComponent<MeshRenderer>().material = selectedCountry;
                // rifleParticle.Play();
            }
            // Debug.Log($"current: {GetRifle().data.ammo}, later: {GetRifle().data.ammo - 1}");

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            // Fare pozisyonu
            Ray rayyy = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Işın
            RaycastHit hitInfooo;

            // Işın bir objeye çarptıysa
            if (Physics.Raycast(rayyy, out hitInfooo))
            {
                // // Işın başlangıç noktası
                // ray.origin
                // // Işın bitiş noktası
                // hitInfo.point
                // // Işının çarptığı obje
                // hitInfo.collider.gameObject.name

                hitInfooo.collider.gameObject.GetComponent<MeshRenderer>().material = unSelectedCountry;
                // rifleParticle.Play();
            }
            // Debug.Log($"current: {GetRifle().data.ammo}, later: {GetRifle().data.ammo - 1}");

        }
    }
}
