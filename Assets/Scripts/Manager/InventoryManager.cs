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


    public List<Button> inventoryImgBT = new List<Button>();

    public List<GameObject> inventoryImg = new List<GameObject>();


    public void Update()
    {

    }

    public void InventorySellect()
    {
        for (int i = 0; i < inventoryImgBT.Count; i++)
        {
            for (int j = 0; j < inventoryImg.Count; j++)
            {

            }
        }

    }


public void OnClickInvenBT()
    {
        healthCondition.SetActive(false);
        inven.SetActive(true);
        rightSet.SetActive(true);
        leftSet.SetActive(true);
    }
    public void OnClickHealthBT()
    {
        healthCondition.SetActive(true);
        inven.SetActive(false);
        rightSet.SetActive(true);
        leftSet.SetActive(true);
    }

    public void OnClickBT()
    {
        inven.SetActive(false);
        healthCondition.SetActive(false);
        rightSet.SetActive(false);
        leftSet.SetActive(false);
    }
}
