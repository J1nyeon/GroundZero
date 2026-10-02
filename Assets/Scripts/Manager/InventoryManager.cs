using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
   public enum E_Inventroy_Tab
    {
        None= -1,
        Information = 0,
        Inven,
        Health,
        Skill,
        Map,
        Duty,
        Challenge
    }
    public GameObject inven;
    public GameObject healthCondition;
    public GameObject leftSet;
    public GameObject rightSet;


    

    public List<GameObject> listInventoryImg = new List<GameObject>();

    public void Start()
    {
        listInventoryImg[(int)E_Inventroy_Tab.Inven].SetActive(true);
    }

    public void InventorySellect(E_Inventroy_Tab ActiveIndexNumber)
    {
        
        for (int i = 0; i < listInventoryImg.Count; i++)
        {
            if (i == (int)ActiveIndexNumber)
            {
                listInventoryImg[i].SetActive(true);
                continue;
            }
            listInventoryImg[i].SetActive(false);
        }
    }


    public void OnClickInformationBT()
    {
        OnClickInven();
        InventorySellect(E_Inventroy_Tab.Information);
    }

    public void OnClickInvenBT()
    {
        healthCondition.SetActive(false);
        inven.SetActive(true);
        rightSet.SetActive(true);
        leftSet.SetActive(true);
        InventorySellect(E_Inventroy_Tab.Inven);
    }
    public void OnClickHealthBT()
    {
        healthCondition.SetActive(true);
        inven.SetActive(false);
        rightSet.SetActive(true);
        leftSet.SetActive(true);
        InventorySellect(E_Inventroy_Tab.Health);

    }

    public void OnClickSkillBT()
    {
        OnClickInven();
        InventorySellect(E_Inventroy_Tab.Skill);
    }

    public void OnClickMapBT()
    {
        OnClickInven();
        InventorySellect(E_Inventroy_Tab.Map);
    }

    public void OnClickDutyBT()
    {
        OnClickInven();
        InventorySellect(E_Inventroy_Tab.Duty);
    }
    public void OnClickChallengeBT()
    {
        OnClickInven();
        InventorySellect(E_Inventroy_Tab.Challenge);
    }


    public void OnClickInven()
    {
        inven.SetActive(false);
        healthCondition.SetActive(false);
        rightSet.SetActive(false);
        leftSet.SetActive(false);
    }
}
