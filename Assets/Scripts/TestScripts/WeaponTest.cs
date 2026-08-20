using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponTest : MonoBehaviour
{
    public WeaponData data;
    public BulletPoolingTest pool;

    public int bullet;
    public float currnetDamage;
    public Transform muzzlePos;
    public bool reloadCheck = false;
    public bool canShoot = true;
    public float nextFireTime;
    public float maxDistance = 100f;

    public Animator animator;

    public float takeWeaponAniTime = 1.2f;
   

    public void Awake()
    {
        if (data != null)
        {
            bullet = data.maxBullet;
            currnetDamage = data.currentShotDamage;
        }
        
    }
    public void OnEnable()
    {
        StartCoroutine(CoWeaponStartAnim());
    }

    public void Fire()
    {
        
        if (reloadCheck == false && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + data.fireRate;
        }
    }
    public void Shoot()
    {
        if (canShoot == false) return;

        bullet--;
        Debug.Log($"남은 탄약 개수 : {bullet}");

        Vector3 center = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = Camera.main.ViewportPointToRay(center);
        Vector3 targetPos;

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            targetPos = hit.point;
        }
        else
        {
            targetPos = ray.GetPoint(maxDistance);
        }
        

        Vector3 dir = (targetPos - muzzlePos.position).normalized;
        GameObject po = pool.GetBullet();
        po.transform.position = muzzlePos.position;
        //po.transform.rotation = muzzlePos.rotation;
        //po.transform.rotation = Camera.main.transform.rotation;

        po.transform.forward = dir;

        po.SetActive(true);

        
    }

    public void Reload()
    {
        if (reloadCheck == true) return;
        StartCoroutine(CoReload());
    }

    private IEnumerator CoReload()
    {
        reloadCheck = true;
        canShoot = false;
        animator.SetBool("Is Reloading", true);

        Debug.Log("장전중 .. ");

        yield return new WaitForSeconds(data.reloadTime);

        bullet = data.maxBullet;
        animator.SetBool("Is Reloading", false);
        reloadCheck = false;
        canShoot = true;
        Debug.Log("장전 완료");
    }

    private IEnumerator CoWeaponStartAnim()
    {
        canShoot = false;

        yield return new WaitForSeconds(takeWeaponAniTime);
        canShoot = true;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.red);
    }
}
