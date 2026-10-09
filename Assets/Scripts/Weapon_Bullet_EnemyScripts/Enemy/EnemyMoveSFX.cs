using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSFX : MonoBehaviour
{
    public InGameSoundManager soundManager;
    public AudioSource enemyMoveSource;
    public List<AudioClip> listMoveClipSFX;
    // Start is called before the first frame update
    public void MoveSound()
    {
        AudioClip clip = listMoveClipSFX[Random.Range(0, listMoveClipSFX.Count)];

        if (enemyMoveSource.isPlaying == false)
        {
            soundManager.PlayOneSFX(enemyMoveSource, clip);
        }
    }
}
