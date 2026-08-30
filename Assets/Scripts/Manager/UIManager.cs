using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

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
            slider.value = currentHp / maxHp;
        }
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
    

}
