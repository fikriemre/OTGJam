using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject flowers;
    public bool startPoint = false;

    public bool endPoint = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.AssignCheckpoint(gameObject.transform.position);
        flowers.SetActive(true);

        if (endPoint)
        {
            GameManager.Instance.LoadNextScene();
        }
    }
}
