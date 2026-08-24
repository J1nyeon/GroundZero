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
        isAlive = true;
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
        currentHp -= damage;

        if (currentHp <= 0)
        {
            currentHp = 0f;
            isAlive = false;
        }
    }
    public void Die()
    {
        // LoseUI
    }
        



}
