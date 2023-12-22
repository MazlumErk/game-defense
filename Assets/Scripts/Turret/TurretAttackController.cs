using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class TurretAttackController : MonoBehaviour
{
    [SerializeField] private float turretSpeed;
    [SerializeField] private float turretRate;
    [SerializeField] private GameObject cube;
    private Transform target;
    [SerializeField] private float fireRate = 0;

    private void Start()
    {
        StartCoroutine(DelayedFunction());
    }

    private void Update()
    {
        if (!target) return;
        TurnToTarget();
        TurretShot();
    }

    private void TurretShot()
    {
        // Ray ray = new Ray(transform.position, target.position - transform.position);
        // RaycastHit hitInfo;
        // if (Physics.Raycast(ray, out hitInfo))
        // {
        //     // // Işın başlangıç noktası
        //     // ray.origin
        //     // // Işın bitiş noktası
        //     // hitInfo.point
        //     // // Işının çarptığı obje
        //     // hitInfo.collider.gameObject.name
        //     if (hitInfo.collider.tag == "Zombie")
        //     {
        //         Destroy(hitInfo.collider.gameObject);
        //     }
        // }
        fireRate += Time.deltaTime;
        if (fireRate >= 1)
        {
            fireRate = 0;
            Destroy(target.gameObject);
        }
    }

    private void TurnToTarget()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        lookRotation.x = 0f;
        lookRotation.z = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turretSpeed);
    }

    IEnumerator DelayedFunction()
    {
        ChooseTheTarget(transform.position, 10f);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(DelayedFunction());
    }

    private void ChooseTheTarget(Vector3 center, float radius)
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        if (hitColliders.Length <= 0) return;
        var excludedColliders = hitColliders.Where(collider => collider.GetComponent<ZombieAttackController>() != null).ToArray();
        Debug.Log(excludedColliders.Length);
        if (excludedColliders.Length <= 0) return;
        var sortedColliders = excludedColliders.OrderBy(collider => Vector3.Distance(transform.position, collider.transform.position)).ToArray();
        if(target != sortedColliders[0].transform) fireRate = 0;
        target = sortedColliders[0].transform;
    }
}
