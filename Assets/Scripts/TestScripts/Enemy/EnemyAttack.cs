using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyData data;
    public BulletPoolingTest pool;
    public Transform firePoint;

    public float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            EnemyBulletSpawn();
            timer = 0f;
        }
        
    }
    public void EnemyBulletSpawn()
    {
        GameObject bullet = pool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);        
        }
    }





}

