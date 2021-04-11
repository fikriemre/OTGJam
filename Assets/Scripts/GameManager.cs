using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Game Manager is null");
            return _instance;
        }
    }

    #endregion
  
    public GameObject mainPlayer;

    public ParticleSystem replaceParticle;

    public Vector3 checkPoint;

    private int currentSceneIndex;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(FindStartCheckpoint());
        StartCoroutine(SpawnPlayer());

    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(FindStartCheckpoint());
    }
    
    IEnumerator FindStartCheckpoint()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        foreach (var c in checkpoints)
        {
            if (c.startPoint)
                checkPoint = c.transform.position;
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        Instantiate(mainPlayer, checkPoint, Quaternion.identity);
    }
    
    public void LoadSameScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        StartCoroutine(SpawnPlayer());
    }

    public void LoadNextScene()
    {
        currentSceneIndex += 1;
        SceneManager.LoadScene(currentSceneIndex);
        StartCoroutine(FindStartCheckpoint());
        StartCoroutine(SpawnPlayer());
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void AssignCheckpoint(Vector3 pos)
    {
        checkPoint = pos;
    }

    public void KillPlayer()
    {
        if(Player.Instance)
        {
            Player.Instance.KillPlayer();
            SFXManager.Instance.DeathSound();
            StartCoroutine(DeathSequence());
        }
    }


    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(2);
        LoadSameScene();
    }
    
    public void PlayReplaceEffect(Vector3 pos)
    {
        Instantiate(replaceParticle, pos, Quaternion.identity);
    }
    
    
}
