using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponTest : MonoBehaviour
{
    public WeaponData data;
    public BulletPoolingTest pool;
    public PoolingBulletHoles poolHoles;
    public PoolMuzzleEffect poolMuzzleEffect;

    public int bullet;
    public float currnetDamage;
    public Transform muzzlePos;
    public float maxDistance = 100f;


    public bool canShoot = true;
    public float nextFireTime;
    public bool reloadCheck = false;

    public Animator animator;

    public float takeWeaponAniTime = 1.2f;
    public LayerMask layer;

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
            MuzzleEffect();
            nextFireTime = Time.time + data.fireRate;
        }
        
    }
    public void Shoot()
    {
        if (canShoot == false) return;
        bullet--;
        Debug.Log($"남은 탄약 개수 : {bullet}");
        Vector3 targetPoint;
        Camera cam = Camera.main;

        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, maxDistance, layer))
        {
            targetPoint = hit.point;
            //if (hit.collider.CompareTag("Wall"))
            //{
            //    GameObject holes = poolHoles.GetObjectBulletHoles();
                
            //    holes.transform.position = targetPoint;
            //    holes.transform.rotation = Quaternion.LookRotation(hit.normal);
            //    StartCoroutine(CoEffectSet(holes));
            //}
            Debug.Log("카메라 레이에 충돌한 타겟 : " + hit.collider.gameObject.name);
        }
        else 
        {
            targetPoint =  cam.transform.position + cam.transform.forward * maxDistance;
            Debug.Log("카메라 레이에 충돌한 것 없음 ");
        }
        GameObject po = pool.GetBullet();
        
        Vector3 dir = (targetPoint - muzzlePos.position).normalized;
        po.transform.position = muzzlePos.position;
        po.transform.forward = dir;
        po.SetActive(true);
        
    }
    public void MuzzleEffect()
    {
        GameObject flashEffect = poolMuzzleEffect.GetFlash();
        GameObject smokeEffect = poolMuzzleEffect.GetSmoke();
        flashEffect.transform.position = muzzlePos.position;
        smokeEffect.transform.position = muzzlePos.position;
        StartCoroutine(CoMuzzleEffect(flashEffect,smokeEffect));
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
    public IEnumerator CoMuzzleEffect(GameObject flash, GameObject smoke)
    {
        flash.SetActive(true);
        smoke.SetActive(true);

        yield return new WaitForSeconds(1f);
        flash.SetActive(false);
        smoke.SetActive(false);
    }
    public IEnumerator CoEffectSet(GameObject holes)
    {
        holes.SetActive(true);

        yield return new WaitForSeconds(2f);
        holes.SetActive(false);
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.red);
    }
}
