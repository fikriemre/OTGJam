using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private static SFXManager instance;

    public static SFXManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("SFXManager is null");
            }
            return instance;
        }
    }

    public enum SFXClips
    {
        leaf ,
        grass ,
        rock ,
        jump ,
        walk ,
        detection
    }


    private void Awake()
    {
        instance = this;
    }

    public void PlaySFXSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void EnemyDetectedSound()
    {        
        audioSource.PlayOneShot(audioClips[(int)SFXClips.detection]);
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(audioClips[(int)SFXClips.jump]);
    }

}
