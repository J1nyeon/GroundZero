using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool isAlive;
    public float currentHp;
    public float maxHp = 100f;


    private void Start()
    {
        currentHp = maxHp;        
    }
    private void Update()
    {
        if (isAlive == false)
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        if (currentHp > 0)
        {
            currentHp -= damage;
            isAlive = true;
            if (currentHp <= 0)
            {
                isAlive = false;
            }
        }
    }
    public void Die()
    {
        // LoseUI
    }
        



}
