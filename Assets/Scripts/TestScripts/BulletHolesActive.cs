using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolesActive : MonoBehaviour
{ 
    public void OnEnable()
    {
        StartCoroutine(CoActive());
    }

    public IEnumerator CoActive()
    {

        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
   
}
