using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveTest : MonoBehaviour
{
    public WeaponData data;

    //private Rigidbody rb;
    public float bulletSpeed = 50f;
    //public float bulletForce = 10f;

    public Vector3 startPosition;
    public float maxDistance = 100f;

    //public PoolingBulletHoles holesPool;

    public bool canMove = false;

 
    public void Start()
    {
        startPosition = transform.position;
        canMove = true;
        // rb = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        if (canMove == false)
            return;

        float moveDis = bulletSpeed * Time.deltaTime;

        //TODO.
        //리지드바디 움직임으로 바꾸기.

        transform.Translate(Vector3.forward * moveDis);

        float dis = Vector3.Distance(startPosition, transform.position);
        if (dis >= maxDistance)
        {
            Debug.Log("최대거리에서 벗어남");
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;
        if (other.gameObject.CompareTag("Player")) return;

        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽에 충돌");
            //canMove = false;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyStateTest est = other.gameObject.GetComponent<EnemyStateTest>();
            est.TakeDamage(data.currentShotDamage);
            Debug.Log("적과 충돌");
            //canMove = false;
            gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        //BulletRbMove();
    }
    public void BulletRbMove()
    {
        
        //Vector3 dir = rb.transform.forward;
        //dir *= bulletSpeed;
        //rb.velocity = dir;
    }

}