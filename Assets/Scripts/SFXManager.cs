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

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFXSound(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    public void EnemyDetectedSound()
    {
        
        audioSource.PlayOneShot(audioClips[0]);
    }

}
