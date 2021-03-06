using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource walkCycleAudioSource;
    public AudioSource enemySound;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public static SFXManager Instance;

   

    public enum SFXClips
    {    
        walk = 0,
        jump = 1,
        drop = 2,       
        enemyWalk = 3,
        detection = 4,
        asd = 5,
        death = 6
    }


    private void Awake()
    {
     
        Instance = this; 
    }

    public void PlaySFXSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public AudioSource EnemyIdleSound()
    {
        return enemySound;
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
    // public void EnemyVoice()
    // {
    //     audioSource.PlayOneShot(audioClips[(int)SFXClips.enemyVoice]);
    // }
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
