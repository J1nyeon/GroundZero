using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling instance;

    public List<GameObject> bulletPool = new List<GameObject>();
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    


}
