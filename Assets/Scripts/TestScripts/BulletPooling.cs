using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public List<GameObject> listBullet = new List<GameObject>();
    private int poolSize = 60;
    public GameObject prfBullet;

    private void Awake()
    {
        BulletPoolSetting();
    }
    private void BulletPoolSetting()
    {
        for (int bullet = 0; bullet < poolSize; bullet++)
        {
            GameObject obj = Instantiate(prfBullet, transform);

            obj.SetActive(false);
            listBullet.Add(obj);
        }
    }
    public GameObject GetObjectSetting()
    {
        for (int bulletIndex = 0; bulletIndex < listBullet.Count; bulletIndex++)
        {
            if (listBullet[bulletIndex].activeSelf == false)
            {
                return listBullet[bulletIndex];
            }
        }
        return null;
    }
    


    


}
