using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTestScripts : MonoBehaviour
{
    public AudioSource left;
    public AudioSource rigth;


    public void OnClickLeftButton() 
    {
        left.Play();
    }
    public void OnClickRigthButton()
    {
        rigth.Play();
    }

}
