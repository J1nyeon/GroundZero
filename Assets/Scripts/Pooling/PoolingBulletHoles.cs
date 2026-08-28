using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBulletHoles : MonoBehaviour
{
    public static PoolingBulletHoles instance;

    public List<GameObject> listBulletHoles = new List<GameObject>();

    public int poolSize = 60;

    public GameObject prfBulletHoles;

    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        SetBulletHolesPool();
    }

    public void SetBulletHolesPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prfBulletHoles, transform);
            obj.SetActive(false);
            listBulletHoles.Add(obj);
        }
    }


    public GameObject GetObjectBulletHoles()
    {
        for (int i = 0; i < listBulletHoles.Count; i++)
        {
            if (listBulletHoles[i].activeSelf == false)
            {
                return listBulletHoles[i];
            } 
        }
        return null;
    }
    public void HolesBool()
    {
        GetObjectBulletHoles().SetActive(true);
    }
}
