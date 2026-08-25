using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateTest : MonoBehaviour
{
    public EnemyData data;
    public float EnemyHp;
    public Slider hpSlider;

    [Header("State")]
    public Rigidbody rb;
    public float moveSpeed = 3f;
    public float distance = 3f;
    public Transform target;

    [Header("Circle")]
    [Range(0, 30)]
    public float viewRange;
    [Range(0, 360)]
    public float viewAngle;


    public float radius = 3f;

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

    public void Idle()
    {
        rb.velocity = Vector3.zero;
    }

    public void Move()
    {
        Vector3 dir = rb.transform.forward;
        rb.velocity = dir * moveSpeed;
    }
    public void Patrol()
    {
        Vector3 m = (target.position - transform.position).normalized;
        float dis = Vector3.Distance(transform.position, target.position);

        if (dis <= 0)
        {
            
        }

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

    public void OnDrawGizmos()
    {
        Handles.DrawSolidArc(transform.position,Vector3.up,transform.forward, viewAngle/2f, radius);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -viewAngle / 2f, radius);

    }

}
