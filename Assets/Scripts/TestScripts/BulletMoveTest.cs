using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletMoveTest : MonoBehaviour
{
    public WeaponData data;

    private Rigidbody rb;
    public float bulletSpeed = 50f;

    public Vector3 startPosition;
    public float maxDistance = 100f;

    public bool canMove = false;

    //public DecalProjector projector;

 
    public void Start()
    {
        startPosition = transform.position;
        canMove = true;
        rb = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        if (canMove == false)
            return;

        //float moveDis = bulletSpeed * Time.deltaTime;

        ////TODO.
        ////리지드바디 움직임으로 바꾸기.

        //transform.Translate(Vector3.forward * moveDis);

        float dis = Vector3.Distance(startPosition, transform.position);
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
            GameObject bulletHoles = PoolingBulletHoles.instance.GetObjectBulletHoles();
            bulletHoles.transform.position = transform.position;
            bulletHoles.transform.LookAt(Camera.main.transform);
            bulletHoles.SetActive(true);

            //projector.transform.LookAt(startPosition);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyFSM enemyFSM = other.gameObject.GetComponent<EnemyFSM>();
            enemyFSM.TakeDamage(data.currentShotDamage);
            Debug.Log("적과 충돌");
            //canMove = false;
            gameObject.SetActive(false);
        }

    }

    public void FixedUpdate()
    {
        BulletRbMove();
    }
    public void BulletRbMove()
    {
        Vector3 dir = rb.transform.forward;
        dir *= bulletSpeed;
        rb.velocity = dir;
    }

    

}