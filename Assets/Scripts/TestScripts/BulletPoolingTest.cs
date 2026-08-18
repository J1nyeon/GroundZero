using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPoolingTest : MonoBehaviour
{
    public int poolSize = 60;
    public List<GameObject> listBulletSet = new List<GameObject>();
    public GameObject prfBullet;

    public void Awake()
    {
        PoolSetting();
    }
    public void PoolSetting()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(prfBullet, transform);
            bullet.SetActive(false);
            listBulletSet.Add(bullet);
        }
    }
    public GameObject GetBullet()
    {
        for (int i = 0; i < listBulletSet.Count; i++)
        {
            if (listBulletSet[i].activeSelf == false)
            {
                return listBulletSet[i];
            }
        }
        return null;
    }
   
}
