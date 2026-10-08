using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    public AudioSource sfxSource;
    public List<AudioSource> audioSFX;
    // public List<string> listPlayingSFX;

    public void Awake()
    {
        //audioSFX = new List<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


    public void PlayOneSFX(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }


    //public void PlaySFX_Áßº¹¾ÈµÊ(AudioClip clip)
    //{
    //    if (listPlayingSFX.Contains(clip.name))
    //    {
    //        return;
    //    }

    //    for (int i = 0; i < listPlayingSFX.Count; i++)
    //    {

    //        if (listPlayingSFX[i] == clip.name)
    //        {
    //            return;
    //        }
    //    }
    //    listPlayingSFX.Add(clip.name);
    //    sfxSource.PlayOneShot(clip);
    //    StartCoroutine(CoPlayingSFX(clip.name, clip.length));
    //}

    //IEnumerator CoPlayingSFX(string name, float length)
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    listPlayingSFX.Remove(name);
    //}

}
