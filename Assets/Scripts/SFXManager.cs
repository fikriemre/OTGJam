using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource walkCycleAudioSource;
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
        walk = 0,
        jump = 1,
        drop = 2,       
        enemyWalk = 3,
        enemyVoice = 4,
        detection = 5,
        death = 6
    }


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFXSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void WalkSound(bool canPlay)
    {
        if (canPlay)
        {
            walkCycleAudioSource.volume = 1;
        }
        else
        {
            walkCycleAudioSource.volume = 0;
        }

    }
    public void JumpSound()
    {
        audioSource.PlayOneShot(audioClips[(int)SFXClips.jump]);
    }
    public void DropSound()
    {
        audioSource.PlayOneShot(audioClips[(int)SFXClips.drop]);
    }
    
    public void EnemyWalkSound()
    {
        audioSource.PlayOneShot(audioClips[(int)SFXClips.enemyWalk]);
    }
    public void EnemyVoice()
    {
        audioSource.PlayOneShot(audioClips[(int)SFXClips.enemyVoice]);
    }
    public void EnemyDetectedSound()
    {        
        audioSource.PlayOneShot(audioClips[(int)SFXClips.detection]);
    }
    // public void EnemyHitSound()
    // {
    //     audioSource.PlayOneShot(audioClips[(int)SFXClips.enemyHit]);
    // }
    public void DeathSound()
    {
        audioSource.PlayOneShot(audioClips[(int)SFXClips.death]);
    }
}
