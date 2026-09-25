using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    public static GameSceneLoader instance;

    public GameObject exitGO;
    public GameObject characterSellect;
    public GameObject mapSellect;
    public GameObject loadingActive;
    public GameObject titleUI;
    public string loadingScene = "LoadingScene";
    public string settingScene = "SettingScene";
    public string gameScene = "GameScene";
    public string tittleScene = "TittleScene";

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Time.timeScale = 1.0f;


    }
    public void OnClickTitleLoader()
    {
        SceneManager.LoadScene(tittleScene);
        CursorManager.instance.CursorOn();
    }
    public void OnClickReGame()
    {
        SceneManager.LoadScene(gameScene);
        CursorManager.instance.CursorOn();
    }

    public void OnClickLoadingScene()
    {
        SceneManager.LoadScene(loadingScene);
    }
    public void OnClickExitGameObject()
    {
        exitGO.SetActive(true);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickProgess()
    {
        exitGO.SetActive(false);
    }

    public void OnClickCharacterSellect()
    {
        titleUI.SetActive(false);
        characterSellect.SetActive(true);
    }

    public void OnClickCharacterSellectExit()
    {
        characterSellect.SetActive(false);
        titleUI.SetActive(true);
    }

    public void OnClickMapSellect()
    {
        mapSellect.SetActive(true);
        characterSellect.SetActive(false);
    }

    public void OnClickMapSellectExit()
    {
        mapSellect.SetActive(false);
        characterSellect.SetActive(true);
    }

    public void OnClickLoadingSet()
    {
        mapSellect.SetActive(false);
        loadingActive.SetActive(true);
    }
    public void OnClickLoadingExit()
    {
        loadingActive.SetActive(false);
        titleUI.SetActive(true);
    }

}
