using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReload : MonoBehaviour
{
    public AudioSource reloadSourceStart;
    public AudioSource reloadSourceEnd;


    public void OnReloadStart()
    {
        reloadSourceStart.Play();
    }
    public void OnReloadEnd()
    {
        reloadSourceEnd.Play();
    }
}

