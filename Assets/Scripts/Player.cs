using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
   public LayerMask targetLayer;

   public bool isMainCharacter;

   public float speedMult;
   public float jumpMult;

   public Collider2D collider;
   public Rigidbody2D rb;
 
   public void ChangePlayerControl()
   {
      RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, Vector2.up, 0.1f, targetLayer);

      if (hit.collider != null)
      {
         Instantiate(hit.collider.gameObject, transform.position, Quaternion.identity);
         if(!isMainCharacter)
            Destroy(gameObject);
         else
         {
            
         }
         Debug.Log(hit.collider.gameObject.name);
         
      }
   }

   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(transform.position, 2);
   }
}
