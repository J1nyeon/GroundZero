using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public EnemyData data;
    public BulletPoolingTest pool;
    public Transform firePoint;
    public Transform targetPlayer;

    public EnemyDetectionZone edz;

    public float timer = 0;
    public float turnSpeed = 5f;
    public NavMeshAgent agent;

    void Update()
    {

        if (edz.canAttack == true && targetPlayer != null)
        {
            //agent.SetDestination(targetPlayer.position);

            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                timer = 0;
                EnemyBulletSpawn();
            }

            Vector3 dir = (targetPlayer.position - transform.position).normalized;
            dir.y = 0;
            if (dir != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                float smoothMove = Time.deltaTime * turnSpeed;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothMove);
            }
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

