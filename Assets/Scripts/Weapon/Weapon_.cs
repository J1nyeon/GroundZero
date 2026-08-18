using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ : MonoBehaviour
{
    public WeaponData weaponData;
    public PoolingBullet poolBullet;
    public PoolingBulletHoles poolBulletHoles;
    public Camera cam;

    [Header("총알 정보")]
    public int currentBullet;
    public float damage;
    public float maxDistance = 100f;
    public Transform trnMuzzle;
    public float nextFireTime = 0f;

    [Header("재장전")]
    public bool isReloading = false;

    [Header("애니메이션")]
    public Animator animatorReload;


    private void Awake()
    {
        if (weaponData !=null)
        {
            damage = weaponData.currentShotDamage;
            currentBullet = weaponData.maxBullet;
        }
    }

    public void Fire()
    {
        if (isReloading == false && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + weaponData.fireRate;
        }
    }
    public void Shoot()
    {
        currentBullet--;
        Debug.Log($"남은 총알 개수 : {currentBullet}");
        Vector3 center = new Vector3(0.5f, 0.5f, 0f); // 중앙
        Ray ray = cam.ViewportPointToRay(center); // 카메라 중앙에서부터 위치
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            targetPoint = hit.point; // 히트포인트로 이동. 
            // 총알이 중간에 없어지는것을 방지
            if (hit.collider.CompareTag("Enemy"))
            {
                // 데미지 && 피흔적 이펙트
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                // 총알 흔적 or 이펙트
                GameObject pBH = poolBulletHoles.GetObjectBulletHoles();
                pBH.transform.position = hit.point;
                pBH.transform.rotation = Quaternion.LookRotation(Vector3.back);
                StartCoroutine(CoBulletHoles(pBH));
                //Debug.Log("벽에 닿음");
            }
        }
        else
        {
            targetPoint = ray.GetPoint(maxDistance); // 레이의 끝지점, 총알의 사거리만큼 이동.
            //Debug.Log("최대사거리 이동");
        }
        Vector3 dir = (targetPoint - trnMuzzle.position).normalized; 

        GameObject bulletObj = poolBullet.GetObject(); // 총알풀의 GetObject()의 정보를 불러와 저장

        if (bulletObj != null)
        {
            bulletObj.transform.position = trnMuzzle.position; // 위치는 총구위치
            bulletObj.transform.forward = dir; // 방향은 보는방향, 화면 정중앙
            BulletMove bulletmove = bulletObj.GetComponent<BulletMove>();
            if (bulletmove != null)
            {
                bulletmove.Setup(targetPoint); // 총알에 targetPoint의 정보를 보내줌
            }
            bulletObj.SetActive(true); // 풀안에있는 총알 Active를 킴
        }
    }
    public void Reload()
    {
        if (isReloading == true) return;
        StartCoroutine(CoReloadTime());
    }

    public IEnumerator CoReloadTime()
    {
        isReloading = true;
        animatorReload.SetBool("Is Reloading", true);
        yield return new WaitForSeconds(weaponData.reloadTime);

        currentBullet = weaponData.maxBullet;
        animatorReload.SetBool("Is Reloading", false);
        isReloading = false;
        Debug.Log($"장전완료. 현재 총알 : {currentBullet}");

    }
    public IEnumerator CoBulletHoles(GameObject pBH)
    {
        pBH.SetActive(true);

        yield return new WaitForSeconds(2f);
        pBH.SetActive(false);


    }
}
