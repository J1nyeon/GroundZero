using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float headShotDamage;
    public float currentShotDamage;
    public float reloadTime;
    public float fireRate;
    public int maxBullet;

}
