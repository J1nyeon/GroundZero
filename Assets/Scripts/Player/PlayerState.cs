using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public InGameUIManager gameUIManager; 
    public float currentHp;
    public float maxHp = 100f;

    public Slider hpSlider;
    
    private void Start()
    {
        hpSlider.value = 1f;
        currentHp = maxHp;      
    }
    public void Update()
    {
        gameUIManager.HpUI(hpSlider, currentHp, maxHp);
    }

    public void TakeDamage(float damage)
    {
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        currentHp -= damage;

        if (currentHp <= 0)
        {
            currentHp = 0f;
            gameUIManager.Lose();
        }
        //UIManager.instance.HpUI(hpSlider, currentHp, maxHp);
    }
}
