using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBullet : MonoBehaviour
{
    public EnemyData data;
    private Rigidbody rb;
    
    public float bulletSpeed = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) return;

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerState ps = other.gameObject.GetComponent<PlayerState>();
            if (ps != null)
            {
                ps.TakeDamage(data.currentDamage);
            }
            gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }


    public void FixedUpdate()
    {
        BulletMove();
    }
    public void BulletMove()
    {
        Vector3 dir = rb.transform.forward;
        rb.velocity = dir * bulletSpeed;

    }

   
}
