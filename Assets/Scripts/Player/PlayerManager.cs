using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool interaction = false;
    public GameObject exitPoint;
    //public GameObject goInteraction;
    //public Image interactionUI;
    public TextMeshProUGUI txtInteraction;

    //public bool escapeUICheck = false;
    [Header("EscapeCountDown")]
    public float countDownTimer;
    public float escapeTimer = 10f;
    public GameObject obEscapeUI;
    public bool countDownCheck = false;

    public GameObject inventoryTab;
    public bool isCursorVisible = true;
    public bool isLocked = true;
    public PlayerCameraController PCC;
    public WeaponController WC;

    public GameObject escImage;



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
            //goInteraction.SetActive(true);
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
            //goInteraction.SetActive(false);
            obEscapeUI.SetActive(false);
            countDownTimer = escapeTimer;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //CursorManager.instance.isCursorVisible = !CursorManager.instance.isCursorVisible;
            inventoryTab.SetActive(!inventoryTab.activeSelf);
            
            //Cursor.visible = !CursorManager.instance.isCursorVisible;
            CursorLockChange();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escImage.SetActive(!escImage.activeSelf);
            CursorLockChange();
        }
    }

    public void CursorLockChange()
    {
        isCursorVisible = !isCursorVisible;
        Cursor.visible = !isCursorVisible;
        if (isLocked == true)
        {
            CursorUnLock();
            PCC.enabled = false;
            WC.enabled = false;
        }
        else
        {
            CursorLock();
            PCC.enabled = true;
            WC.enabled = true;
        }
    }
    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isLocked = true;
    }

    public void CursorUnLock()
    {
        Cursor.lockState = CursorLockMode.None;
        isLocked = false;
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
