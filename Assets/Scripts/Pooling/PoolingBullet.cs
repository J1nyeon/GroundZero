using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBullet : MonoBehaviour
{
    public List<GameObject> listBullet = new List<GameObject>();

    public float poolSize = 60;

    public GameObject prfBullet;


    public void Awake()
    {
        BulletPoolSet(); // 시작시 호출
    }
    public void BulletPoolSet() // 총알 풀 세팅
    {
        for (int i = 0; i < poolSize; i++) // poolSize만큼
        {
            GameObject obj = Instantiate(prfBullet, transform); // 추가해줌
            obj.SetActive(false); // 시작하면 꺼둔상태로
            listBullet.Add(obj); // 리스트에 추가
        }
    }
    public GameObject GetObject() 
    {
        for (int i = 0; i < listBullet.Count; i++) // 리스트를 순회하면서
        {
            if (listBullet[i].activeSelf == false) // 리스트 내부의 false인 오브젝트를 찾음
            {
                return listBullet[i]; // 해당 오브젝트를 반환해줌
            }
        }
        return null; // false인 총알이 없으면 null 반환
    }
}
