using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
   
    public GameObject inven;
    public GameObject healthCondition;
    public GameObject leftSet;
    public GameObject rightSet;


    

    public List<GameObject> listInventoryImg = new List<GameObject>();

    public void Start()
    {
        listInventoryImg[1].SetActive(true);
    }

    public void InventorySellect(int ActiveIndexNumber)
    {
        
        for (int i = 0; i < listInventoryImg.Count; i++)
        {
            if (i == ActiveIndexNumber)
            {
                listInventoryImg[ActiveIndexNumber].SetActive(true);
                continue;
            }
            listInventoryImg[i].SetActive(false);
        }
    }


    public void OnClickInformationBT()
    {
        OnClickInven();
        InventorySellect(0);
    }

    public void OnClickInvenBT()
    {
        healthCondition.SetActive(false);
        inven.SetActive(true);
        rightSet.SetActive(true);
        leftSet.SetActive(true);
        InventorySellect(1);
    }
    public void OnClickHealthBT()
    {
        healthCondition.SetActive(true);
        inven.SetActive(false);
        rightSet.SetActive(true);
        leftSet.SetActive(true);
        InventorySellect(2);

    }

    public void OnClickSkillBT()
    {
        OnClickInven();
        InventorySellect(3);
    }

    public void OnClickMapBT()
    {
        OnClickInven();
        InventorySellect(4);
    }

    public void OnClickDutyBT()
    {
        OnClickInven();
        InventorySellect(5);
    }
    public void OnClickChallengeBT()
    {
        OnClickInven();
        InventorySellect(6);
    }


    public void OnClickInven()
    {
        inven.SetActive(false);
        healthCondition.SetActive(false);
        rightSet.SetActive(false);
        leftSet.SetActive(false);
    }
}
