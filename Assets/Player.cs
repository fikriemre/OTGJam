using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   public LayerMask targetLayer;

   public float speedMult;
   public float jumpMult;

   public Collider2D collider;
   public Rigidbody2D rb;

   public void ChangePlayerControl()
   {
      RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, Vector2.up, 0.1f, targetLayer);

      if (hit.collider != null)
      {
         Debug.Log("Hit!");
      }
   }

}
