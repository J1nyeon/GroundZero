using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPoolingTest : MonoBehaviour
{
    public int poolSize = 60;
    public List<GameObject> listBullet = new List<GameObject>();
    public GameObject prfBullet;

    public void Awake()
    {
        PoolSet();
    }
    public void PoolSet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(prfBullet, transform);
            bullet.SetActive(false);
            listBullet.Add(bullet);
        }
    }
    public GameObject GetBulletSet()
    {
        for (int i = 0; i < listBullet.Count; i++)
        {
            if (listBullet[i].activeSelf == false)
            {


            }
        }

        return null;
    }


}
