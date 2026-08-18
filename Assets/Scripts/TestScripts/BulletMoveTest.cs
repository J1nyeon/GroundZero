using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveTest : MonoBehaviour
{
    public float bulletSpeed = 50f;

    public Vector3 targetPosition;

    public void Setup(Vector3 targetPoint)
    {
        targetPosition = targetPoint;
    }
    public void Update()
    {
        float moveDis = bulletSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDis);
        float dis = Vector3.Distance(targetPosition, transform.position);
        if (dis <= 0.5f)
        {
            gameObject.SetActive(false);
        }
    }
}
