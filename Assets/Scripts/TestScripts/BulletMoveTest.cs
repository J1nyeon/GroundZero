using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveTest : MonoBehaviour
{
    public WeaponData data;

    private Rigidbody rb;
    public float bulletSpeed = 50f;

    public Vector3 startPosition;
    public float maxDistance = 100f;

    public bool canMove = false;

 
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
            bulletHoles.transform.LookAt(Camera.main.transform,Vector3.down);
            bulletHoles.SetActive(true);
            // 회전을 어떻게 해야하지 ?
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
        BulletRbMove();
    }
    public void BulletRbMove()
    {

        Vector3 dir = rb.transform.forward;
        dir *= bulletSpeed;
        rb.velocity = dir;
    }

    public IEnumerator CoHolesPool(GameObject bulletHoles)
    {
        bulletHoles.SetActive(true);
        yield return new WaitForSeconds(1f);
        bulletHoles.SetActive(false);
    }

}