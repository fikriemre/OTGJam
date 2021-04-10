using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musics;

   private static MusicManager instance;

   public static MusicManager Instance
   {
        get
        {
            if(instance == null)
            {
                Debug.LogError("MusicManager is null");
            }
            return instance;
        }
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

    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource.PlayClipAtPoint(musicClip, transform.position);
    }

}
