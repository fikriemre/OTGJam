using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool startPoint = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.AssignCheckpoint(gameObject.transform.position);
    }
}
