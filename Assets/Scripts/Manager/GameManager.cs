using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InGameUIManager gameUIManager;
    public float time = 300;
    public int hour;
    public int minute;
    public int second;
    public TextMeshProUGUI timerText;


    public enum GameState 
    {
        None = -1,
        Play,
        Win,
        Lose
    }
    public static GameState currentState;

    private void Awake()
    {
        currentState = GameState.Play;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (Time.timeScale == 1)
        {
            RealTime();
            TimeOver();
        }
    }

    public void RealTime()
    {
        hour = 0;
        minute = (int)(time / 60);
        second = (int)(time % 60);
        timerText.text = $"{hour:0}:{minute:00}:{second:00}";
    }

    public void TimeOver()
    {
        if (second == 0 && minute == 0)
        {
            gameUIManager.Lose();
            Debug.Log("타임아웃 패배");
            //timerText.text = $"{minute: 00} :{00 : 00}";
        }
    }
}
