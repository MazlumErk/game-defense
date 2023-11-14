using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RifleShot : MonoBehaviour
{
    [SerializeField] private GameObject kup;
    [SerializeField] private AudioSource rifleShoutSound;
    private Vector3 cizgiSon;

    [SerializeField] private bool RifleMode;
    [SerializeField] private float fireRate = 0.2f, currentRate;

    private void Start()
    {
        currentRate = fireRate;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonu
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // // Işın
            // RaycastHit hitInfo;

            // // Işın bir objeye çarptıysa
            // if (Physics.Raycast(ray, out hitInfo))
            // {
            //     // // Işın başlangıç noktası
            //     // Debug.Log("Işın Başlangıç Noktası: " + ray.origin);
            //     // // Işın bitiş noktası
            //     // Debug.Log("Işın Bitiş Noktası: " + hitInfo.point);
            //     // // Işının çarptığı obje
            //     Debug.Log("Işın çarptı: " + hitInfo.collider.gameObject.name);



            //     // Line oluştur, line başlangıç ve bitiş kordinatlarını ayarla
            //     cizgiSon = hitInfo.point;
            //     if (!hitInfo.collider.GetComponent<CubeController>())
            //     {
            //         Instantiate(kup, cizgiSon, Quaternion.identity);
            //     }
            //     if (hitInfo.collider.tag == "Zombie")
            //     {
            //         Destroy(hitInfo.collider.gameObject);
            //         Debug.Log("zombie!!!!");
            //     }
            //     if (hitInfo.collider.tag == "Wall")
            //     {
            //         Debug.Log("duvar");
            //     }
            //     rifleShoutSound.Play();

            // Debug.Log(cizgi.GetComponent<LineRenderer>().GetPosition(0));
        }
        if (Input.GetKey(KeyCode.Mouse0) && RifleMode)
        {
            currentRate += Time.deltaTime;
            if (currentRate >= fireRate)
            {

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
                }
                currentRate = 0;
            }

        }

        // if(Input.GetMouseButtonDown(0)){
        //     rifleShoutSound.Play();
        //     rifleShoutSound.loop = true;
        // }

        // if(Input.GetMouseButtonUp(0)){
        //     rifleShoutSound.Stop();
        //     rifleShoutSound.loop = false;
        // }
    }
}
