using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("EscapeUI")]
    public Image escapeUI;
    public Image escapeTimerUI;
    public TextMeshProUGUI escapeTimerTxt;
    public bool escapeUICheck = false;

    [Header("Win & Lose")]
    public TextMeshProUGUI txtUI;
    public GameObject winOrLose;
    public Image fadeOverlay;




    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); 
        }
    }
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
        escapeTimerTxt.text = $"{sec:00}:{milsec:00}";
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
        fadeOverlay.DOFade(0.5f, 1.0f).SetEase(Ease.OutQuad).OnComplete(ShowResultUI);
        
    }
    public void Win()
    {
        if(txtUI != null)
        {
            txtUI.text = "You Win";
            txtUI.color = Color.cyan;
            DoGameOverOrWin();
        }
        CursorOn();
    }
    public void Lose()
    {
        if (txtUI != null)
        {
            txtUI.text = "You Lose";
            txtUI.color = Color.cyan;
            DoGameOverOrWin();
        }
        CursorOn();
    }
    public void CursorOn()
    {
        Cursor.lockState = CursorLockMode.Confined; // 커서 윈도우 안에 가두기
        Cursor.visible = true; // 커서 키기
    }
    public void ShowResultUI()
    {
        Time.timeScale = 0f;
        if (winOrLose != null)
        {
            winOrLose.SetActive(true);
        }
    }
    
    public IEnumerator CoEscapeDOTween()
    {
        escapeUI.transform.DOLocalMoveX(398f, 1.0f);
        yield return new WaitForSeconds(2f);
        escapeUI.transform.DOLocalMoveX(688f, 1.0f);
        escapeUICheck = false;
    }

}
