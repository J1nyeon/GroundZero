using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveTest : MonoBehaviour
{
    public float bulletSpeed = 50f;

    public Vector3 targetPosition;
    public float maxDistance = 100f;

    public PoolingBulletHoles holesPool;

    public void Update()
    {
        float moveDis = bulletSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDis);

        float dis = Vector3.Distance(targetPosition, transform.position);
        if (dis >= maxDistance)
        {
            Debug.Log("최대거리에서 벗어남");
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) return;

        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽에 충돌");
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Enemy.TakeDamage(); 
            Debug.Log("적과 충돌");
            gameObject.SetActive(false);
        }
        
    }

}