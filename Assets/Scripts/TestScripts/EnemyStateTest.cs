using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateTest : MonoBehaviour
{
    public EnemyData data;
    public float EnemyHp;
    public Image hpUI;
    
    // Start is called before the first frame update
    private void Awake()
    {
        EnemyHp = data.enemyHp;
    }

    public void TakeDamage(float damage)
    {
        //EnemyHp = Mathf.Clamp(EnemyHp, 0, data.enemyHp);
        
        EnemyHp -= damage;
        Debug.Log("현재 HP : " + EnemyHp);
        if (0 >= EnemyHp)
        {
            Debug.Log("적 처치");
        }
    }
}
