using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateTest : MonoBehaviour
{
    public EnemyData data;
    public float EnemyHp;
    public Slider hpSlider;

    [Header("Circle")]
    [Range(0, 30)]
    public float viewRange;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    
    
    private void Awake()
    {
        hpSlider.value = 1f;
        if (data != null)
        {
            EnemyHp = data.enemyHp;       
        }
    }

    public void LookAtPlayer()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, viewRange, targetMask);
        
    }

    public void TakeDamage(float damage)
    {
        EnemyHp -= damage;
        EnemyHp = Mathf.Clamp(EnemyHp, 0, data.enemyHp);
        
        Debug.Log("현재 HP : " + EnemyHp);
        if (0 >= EnemyHp)
        {
            EnemyHp = 0f;
            Debug.Log("적 처치");
        }
        HPUI();
    }
    public void HPUI()
    {
        if (hpSlider != null)
        {
            hpSlider.value = EnemyHp / data.enemyHp;
        }
    }
    
}
