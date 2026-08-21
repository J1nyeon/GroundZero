using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy/EnemyData")]

public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float enemyHp;
    public float currentDamage;

}
