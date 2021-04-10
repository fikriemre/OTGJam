using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    
    private void Awake()
    {
        _instance = this;
    }
}
