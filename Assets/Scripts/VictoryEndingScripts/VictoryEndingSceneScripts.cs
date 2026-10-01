using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryEndingSceneScripts : MonoBehaviour
{
    public GameObject firstCut;
    public GameObject secondCut;
    public GameObject thirdCut;

    public string tittleScene = "TittleScene";

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnClickFirstCutNextButton()
    {
        firstCut.SetActive(false);
        secondCut.SetActive(true);
    }
    public void OnClickTittleSceneLoad()
    {
        SceneManager.LoadScene(tittleScene);
    }
    public void OnClickSecondCutNextButton()
    {
        secondCut.SetActive(false);
        thirdCut.SetActive(true);
    }

    public void OnClickSecondCutBackButton()
    {
        secondCut.SetActive(false);
        firstCut.SetActive(true);
    }

    public void OnClickThirdCutBackButton()
    {
        thirdCut.SetActive(false);
        secondCut.SetActive(true);
    }
}
