using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingTimer : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timerTxt;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
        }
        int sec = (int)timer;
        int milsec = (int)((timer % 1) * 1000);
        timerTxt.text = $"00:{sec:00}.{milsec:000}";
        
    }
}
