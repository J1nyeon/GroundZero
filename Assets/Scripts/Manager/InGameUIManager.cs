using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [Header("EscapeUI")]
    public Image escapeUI;
    public Image escapeTimerUI;
    public TextMeshProUGUI escapeTimerTxt;
    public bool escapeUICheck = false;

    [Header("Win & Lose")]
    
    public Image fadeOverlay;


    
    public void HpUI(Slider slider, float currentHp, float maxHp)
    {
        if (slider != null)
        {
            slider.value = Mathf.Lerp(slider.value, currentHp / maxHp, Time.deltaTime * 5f);
        }
    }

    public void EscapeTimerUI(float timer)
    {
        int sec = (int)timer;
        int milsec = (int)((timer % 1) * 100);
        escapeTimerTxt.text = "hh";// $"{sec:00}:{milsec:00}";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && escapeUICheck == false)
        {
            escapeUICheck = true;
            DGEscapeUI();
        }
    }

    public void DGEscapeUI()
    {
        StartCoroutine(CoEscapeDOTween());
    }

    public void DoGameOverOrWin()
    {
        if (fadeOverlay != null)
        {
            fadeOverlay.gameObject.SetActive(true);
            fadeOverlay.DOFade(1, 1f).SetEase(Ease.OutQuad).OnComplete(ShowResultUI);
        }

    }
    public void Win()
    {
        DoGameOverOrWin();
        //StartCoroutine(CoVictoryEndingSceneLoder());
    }
    public void Lose()
    {
        //if (txtUI != null)
        //{
        //    txtUI.text = "You Lose";
        //    txtUI.color = Color.cyan;
        //    DoGameOverOrWin();
        //}

    }

    public void ShowResultUI()
    {
        //Time.timeScale = 0f;

        GameSceneLoader.instance.EndingSceneLoader();
        //if (winOrLose != null)
        //{
        //    winOrLose.SetActive(true);
        //}
    }

    public IEnumerator CoEscapeDOTween()
    {
        escapeUI.transform.DOLocalMoveX(398f, 1.0f);
        yield return new WaitForSeconds(2f);
        escapeUI.transform.DOLocalMoveX(688f, 1.0f);
        escapeUICheck = false;
    }

    public IEnumerator CoVictoryEndingSceneLoder()
    {
        DoGameOverOrWin();

        yield return new WaitForSeconds(3f);


    }
}
