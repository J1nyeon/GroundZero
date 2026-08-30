using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleSceneLoader : MonoBehaviour
{
    public static TittleSceneLoader instance;

    public GameObject exitGO;
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
        UIManager.instance.CursorOn();
    }
    public void OnClickReGame()
    {
        SceneManager.LoadScene(gameScene);
        UIManager.instance.CursorOn();
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

    


}
