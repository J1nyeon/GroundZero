using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTimer : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timerTxt;

    public string gameScene = "GameScene";

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            StartCoroutine(CoSceneChangeDelay());
        }
        int sec = (int)timer;
        int milsec = (int)((timer % 1) * 1000);
        timerTxt.text = $"00:{sec:00}.{milsec:000}";
        
    }

    public IEnumerator CoSceneChangeDelay()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(gameScene);

    }
}
