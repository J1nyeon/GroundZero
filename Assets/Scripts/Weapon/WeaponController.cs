using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    //public Weapon_ weapon;

    public WeaponTest test;
    public Animator animator;
    public bool isZoom = false;

    public bool interaction = false;
    public GameObject exitPoint;
    public GameObject goInteraction;
    public Image interactionUI;
    public TextMeshProUGUI txtInteraction;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            test.Fire();
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics.Raycast(pos,Vector3.forward,out RaycastHit hit,100f))
            {
                Debug.Log(hit.collider.name);
            }
            //weapon.Fire();
        }
        ExitDistanse();
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
        //if (Input.GetKeyDown(KeyCode.R) || weapon.currentBullet <= 0)
        //{
        //weapon.Reload();

        //}
        if (Input.GetKeyDown(KeyCode.R) || test.bullet <= 0)
        {
            test.Reload();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            isZoom = true;
        }
        else
        {
            isZoom = false;
        }
        animator.SetBool("ZoomBool", isZoom);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Exit"))
    //    {
    //        interaction = true;
    //    }
    //    else
    //    {
    //        interaction = false;
    //    }
    //}
    public void ExitDistanse()
    {
        float dis = Vector3.Distance(exitPoint.transform.position, transform.position);
        if (dis < 4f)
        {
            interaction = true;
        }
        else
        {
            interaction = false;
        }
    }
}
