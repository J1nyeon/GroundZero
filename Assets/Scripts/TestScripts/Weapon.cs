using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public BulletPooling bulletPool;

    [Header("Weapon Setting")]
    public Transform muzzleTrn;
    public int bullet;
    public float maxDis = 1000f;
    
    public Camera cam;
    public GameObject prf;



    public void Start()
    {
        bullet = data.maxBullet;
    }
    private void Update()
    {
        Debug.DrawRay(muzzleTrn.position, Vector3.forward, Color.red);
    }
    public void Shoot()
    {
        Vector3 center = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = cam.ViewportPointToRay(center);
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out RaycastHit hit, maxDis))
        {
            targetPoint = hit.point;
            if (hit.collider.CompareTag("Wall"))
            {
                Instantiate(prf,targetPoint,Quaternion.Euler(0,180,0));
                Debug.Log("º® Ãæµ¹");
            }
        }
        else
        {
            targetPoint = ray.GetPoint(maxDis);
        }

        Vector3 dir = (targetPoint - muzzleTrn.position).normalized;

        GameObject bullet = bulletPool.GetObjectSetting();

        if (bullet != null)
        {
            bullet.transform.position = muzzleTrn.position;
            bullet.transform.forward = dir;

            bullet.SetActive(true);
        }
    }

}
