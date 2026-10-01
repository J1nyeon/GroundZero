using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCButtonManager : MonoBehaviour
{
    public GameObject progressContinue;
    public string tittleScene = "TittleScene";

    public void OnClickGameProgress()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        progressContinue.SetActive(false);
    }

    public void OnClickTittleSceneLoder()
    {
        SceneManager.LoadScene(tittleScene);
    }
}
