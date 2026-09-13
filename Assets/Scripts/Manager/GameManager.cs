using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float time;
    public int minute;
    public int second;
    public TextMeshProUGUI timerText;


    public enum GameState 
    {
        Win,
        Play,
        Lose
    }
    public GameState currentState;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Time.timeScale == 1)
        {
            RealTime();
            TimeOver();
        }
        //switch (currentState)
        //{
        //    case GameState.Win:

        //        break;
        //    case GameState.Lose:
                
        //        break;
        //}


    }

    public void RealTime()
    {
        minute = (int)(time / 60);
        second = (int)(time % 60);
        timerText.text = $"{minute : 00} :{second : 00}";
    }

    public void TimeOver()
    {
        if (minute == 1)
        {
            UIManager.instance.Lose();
            timerText.text = $"{minute: 00} :{00 : 00}";
        }
    }
}
