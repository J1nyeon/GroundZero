using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CursorOn()
    {
        Cursor.lockState = CursorLockMode.Confined; // 커서 윈도우 안에 가두기
        Cursor.visible = true; // 커서 키기
    }
}
