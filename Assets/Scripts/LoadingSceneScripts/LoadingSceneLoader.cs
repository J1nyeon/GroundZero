using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneLoader : MonoBehaviour
{
    public static LoadingSceneLoader instance;

    public string gameScene = "GameScene";

    public Slider loaingSlider;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Cursor.visible = false;
    }
    public void Start()
    {
        SceneLoader();
    }

    public void SceneLoader()
    {
        StartCoroutine(CoSceneLoader(gameScene));
    }

    public IEnumerator CoSceneLoader(string SceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneName);
        ao.allowSceneActivation = false;
        float timer = 0f;

        while(ao.isDone == false)
        {
            yield return null;
            timer += Time.deltaTime;
            float time = Mathf.Clamp01(timer);
            loaingSlider.value = Mathf.Lerp(loaingSlider.value, ao.progress, time);
            if (loaingSlider.value >= ao.progress)
            {
                loaingSlider.value = Mathf.Lerp(loaingSlider.value, 1f, time);   
            }
            if (ao.progress >= 0.9f && timer >= 1f)
            {
                ao.allowSceneActivation = true;
            }
        }
    }
}
