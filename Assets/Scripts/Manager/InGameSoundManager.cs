using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundManager : MonoBehaviour
{
    

    public void PlayOneSFX(AudioSource source, AudioClip clip)
    {
         source.PlayOneShot(clip);
       
    }
}
