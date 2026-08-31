using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMuzzleEffect : MonoBehaviour
{
    public int poolSize = 60;

    public List<GameObject> listFlashEffect = new List<GameObject>();
    public List<GameObject> listSmokeEffect = new List<GameObject>();

    public GameObject flashEffect;
    public GameObject smokeEffect;


    public void Awake()
    {
        SetEffectPool();
    }
    public void SetEffectPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject flash = Instantiate(flashEffect, transform);
            GameObject smoke = Instantiate(smokeEffect, transform);
            flash.SetActive(false);
            smoke.SetActive(false);
            listFlashEffect.Add(flash);
            listSmokeEffect.Add(smoke);
        }
    }
    public GameObject GetFlash()
    {
        for(int i = 0; i < listFlashEffect.Count; i++)
        {
            if (listFlashEffect[i].activeSelf == false)
            {
                return listFlashEffect[i];
            }
        }
        return null;
    }
    public GameObject GetSmoke()
    {
        for(int i = 0; i< listSmokeEffect.Count; i++)
        {
            if (listSmokeEffect[i].activeSelf == false)
            {
                return listSmokeEffect[i];
            }
        }
        return null;
    }

    
}
