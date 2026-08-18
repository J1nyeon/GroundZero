using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    public WeaponData data;
    public BulletPoolingTest pool;

    public Camera cam;

    public int currentBullet;
    public Transform posMuzzle;
    public float maxDistance = 100f;
    public float currentDamage;

    public void Awake()
    {
        if (data != null)
        {
            currentBullet = data.maxBullet;
            currentDamage = data.currentShotDamage;
        }
    }

    public void Shoot()
    {
        Vector3 center = new Vector3(0.5f, 0.5f, 0);
        Ray ray = cam.ViewportPointToRay(center);
        Vector3 targetPoint;
        
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(maxDistance);
        }

        Vector3 bulletFireDir = (targetPoint - posMuzzle.position).normalized;

        GameObject bullet = pool.GetBullet();

        if (bullet != null)
        {
            bullet.transform.position = posMuzzle.position;
            bullet.transform.forward = bulletFireDir;

            BulletMoveTest BMT = bullet.GetComponent<BulletMoveTest>();

            if (BMT != null)
            {
                BMT.Setup(targetPoint);
            }
            bullet.SetActive(true);
        }


    }


}
