using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Player>())
        {
            GameManager.Instance.KillPlayer();
        }
    }
}
