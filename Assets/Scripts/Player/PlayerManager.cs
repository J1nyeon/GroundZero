using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool interaction = false;
    public GameObject exitPoint;
    public GameObject goInteraction;
    public Image interactionUI;
    public TextMeshProUGUI txtInteraction;

    //public bool escapeUICheck = false;
    [Header("EscapeCountDown")]
    public float countDownTimer;
    public float escapeTimer = 10f;
    public GameObject obEscapeUI;
    public bool countDownCheck = false;
    

    public void Start()
    {
        countDownTimer = escapeTimer;
    }

    private void Update()
    {
        //ExitDistanse();
        
        Debug.Log($"interaction ป๓ลย : {interaction}");
        UIManager.instance.EscapeTimerUI(countDownTimer);
        if (interaction == true)
        {
            goInteraction.SetActive(true);
            obEscapeUI.SetActive(true);
            countDownTimer -= Time.deltaTime;
            if(countDownTimer<= 0)
            {
                countDownTimer = 0f;
                UIManager.instance.Win();
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIManager.instance.Win();
            }
        }
        else
        {
            goInteraction.SetActive(false);
            obEscapeUI.SetActive(false);
            countDownTimer = escapeTimer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            interaction = true;
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            interaction = false;
        }
    }
    public void ExitDistanse()
    {
        float dis = Vector3.Distance(exitPoint.transform.position, transform.position);
        if (dis < 3f)
        {
            interaction = true;
        }
        else
        {
            interaction = false;
        }
    }


}
