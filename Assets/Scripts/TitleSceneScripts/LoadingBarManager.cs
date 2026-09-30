using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBarManager : MonoBehaviour
{
    public string loadingScene = "LoadingScene";

    //public Slider loadingSlider;
    public Image loadingImage;
    public float fillSpeed = 0.5f;
    public int cellCount = 8;

    public float displayValue;
    public void OnEnable()
    {
        displayValue = 0f;
        loadingImage.fillAmount = 0f;
        StartCoroutine(CoLoaderEx(loadingScene));
    }

    public IEnumerator CoLoader(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;

        while (displayValue < 1f)
        {
            float target = Mathf.Clamp01(ao.progress / 0.9f);
            displayValue = Mathf.MoveTowards(displayValue, target, fillSpeed * Time.deltaTime);
            loadingImage.fillAmount = Mathf.Ceil(displayValue * cellCount) / cellCount;

            yield return null;

        }
        ao.allowSceneActivation = true;

    }

    public IEnumerator CoLoaderEx(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;

        float timeInterval = 0.25f;
        float timer = 0;

        int filledCells = 0;
        while (filledCells < cellCount)
        {
            timer += Time.deltaTime;
            float progress = ao.progress / 0.9f;

            int shouldFill = (int)(progress * cellCount);
            
            if(timer >= timeInterval && filledCells < shouldFill)
            {
                timer = 0;
                filledCells++;
                loadingImage.fillAmount = (float)filledCells / cellCount;
            }
            yield return null;
        }
        ao.allowSceneActivation = true;
    }


}
