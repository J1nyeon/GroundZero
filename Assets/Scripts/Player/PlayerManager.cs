using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public InGameUIManager gameUIManager;
    public bool interaction = false;
    public GameObject exitPoint;
    //public GameObject goInteraction;
    //public Image interactionUI;
    //public TextMeshProUGUI txtInteraction;

    //public bool escapeUICheck = false;
    [Header("EscapeCountDown")]
    public float countDownTimer;
    public float escapeTimer = 10f;
    public GameObject obEscapeUI;
    public bool countDownCheck = false;

    public GameObject inventoryTab;
    public PlayerCameraController playerCameraController;
    public WeaponController weaponController;

    public GameObject escImage;
    public string tittleScene = "TittleScene";

    public bool hasTriggeredEnding = false;


   
    public void Start()
    {
        countDownTimer = escapeTimer;
        hasTriggeredEnding = false;
    }

    private void Update()
    {
        //ExitDistanse();
        
        gameUIManager.EscapeTimerUI(countDownTimer);
        if (interaction == true)
        {
            //goInteraction.SetActive(true);
            obEscapeUI.SetActive(true);
            countDownTimer -= Time.deltaTime;
            if(countDownTimer<= 0 )
            {
                countDownTimer = 0f;
                if (hasTriggeredEnding == false)
                {
                    hasTriggeredEnding = true;
                    GameManager.currentState = GameManager.GameState.Win;
                    gameUIManager.Win();
                }
            }
        }
        else
        {
            //goInteraction.SetActive(false);
            obEscapeUI.SetActive(false);
            countDownTimer = escapeTimer;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            StateChage(inventoryTab);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StateChage(escImage);
            //if (escImage.activeSelf == true)
            //{
            //    escImage.SetActive(false);
            //    CursorLockChange(true);
            //}
            //else
            //{
            //    escImage.SetActive(true);
            //    CursorLockChange(false);
            //}
        }
    }

    public void StateChage(GameObject State)
    {
        //State.SetActive(!State.activeSelf);
        //CursorLockChange(State.activeSelf);
        // 아래 코드
        if (State.activeSelf == true)
        {
            State.SetActive(false);
            CursorLockChange(true);
        }
        else
        {
            State.SetActive(true);
            CursorLockChange(false);
        }
    }


    
    public void CursorLockChange(bool isLock)
    {
        Cursor.visible = !isLock;
        if(isLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        playerCameraController.enabled = isLock;
        weaponController.enabled = isLock;
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

    public void OnClickGameProgress()
    {
        escImage.SetActive(false);
        CursorLockChange(true);
    }

    public void OnClickTittleSceneLoder()
    {
        SceneManager.LoadScene(tittleScene);
    }



}
