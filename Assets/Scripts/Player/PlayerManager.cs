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

    private void Update()
    {
        //ExitDistanse();
        Debug.Log($"interaction ป๓ลย : {interaction}");
        if (interaction == true)
        {
            goInteraction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIManager.instance.Win();
            }
        }
        else
        {
            goInteraction.SetActive(false);
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
