using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet Setting")]
    public float maxDistance = 100f; // 최대거리
    public float bulletSpeed = 50f; // 총알 속도
    public LayerMask layer; // 점검할 레이어
    private Vector3 spawnPos; // 스폰포인트 저장

    public Vector3 targetPosition;
    
    private void OnEnable()
    {
        spawnPos = transform.position;
    }
    public void Update()
    {
        float moveDistance = bulletSpeed * Time.deltaTime; // 프레임마다 움직일거리

        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, moveDistance,layer)) 
            // 총알위치, 보는방향, 레이를 맞은 대상의 정보, 움직일거리, 감지할레이어. 
            // 지정한 레이어에 레이가 닿았을경우에 true
        {
            transform.position = hit.point; 
            // 현재위치를 맞은 대상의 좌표로 이동.
            Debug.Log("Bullet Ray Check");
            gameObject.SetActive(false);
            // 총알 오브젝트를 false로 바꿈
            return; 
        }

        transform.Translate(Vector3.forward * moveDistance); // 총알 날아감


        float dis = Vector3.Distance(spawnPos, transform.position);

        if (dis > maxDistance)
        {
            gameObject.SetActive(false);
            Debug.Log("최대거리에서 벗어남");
        }
    }
    public void Setup(Vector3 targetPoint)
    {
        targetPosition = targetPoint;
    }


}
