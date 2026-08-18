using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon_ weapon;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Fire();
        }
        if (Input.GetKeyDown(KeyCode.R) || weapon.currentBullet <= 0)
        {
            weapon.Reload();
        }
       
    }
}
