using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed = 50f;
    public Vector3 targetPos;

    public void Setup(Vector3 targetPoint) // 목표지점을 받아오기 위한 함수
    {
        targetPos = targetPoint;
    }

    public void Update()
    {
        float moveDis = bulletSpeed * Time.deltaTime; // 프레임마다 어느정도 속도로 이동할건지
        transform.Translate(Vector3.forward * moveDis); // 보는방향으로 이동

        float dis = Vector3.Distance(targetPos, transform.position); // 타겟과 총알 위치
        if (dis <= 0.5f) // 총알이 타겟에 닿을경우
        {
            gameObject.SetActive(false); // 총알을 끔
        }  
    }

}
