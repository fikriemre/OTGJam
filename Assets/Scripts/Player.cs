using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static Player Instance;

   public LayerMask targetLayer;

   public bool isMainCharacter;

   public float speedMult;
   public float jumpMult;

   public Collider2D collider;
   public Rigidbody2D rb;

   private void Awake()
   {
      Instance = this;
   }


   public void ChangePlayerControl()
   {
      RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, Vector2.up, 0.1f, targetLayer);

      if (hit.collider != null)
      {
         ChangableObject co = hit.collider.gameObject.GetComponent<ChangableObject>();
         if (co)
         {
            GameObject go = Instantiate(co.myPlayerReplica, transform.position, Quaternion.identity);
            SFXManager.Instance.PlaySFXSound(co.turnObjectSound);
            Destroy(co.gameObject);
            Destroy(gameObject);
         }
      }
   }

   public void TurnBackToOriginal()
   {
      Instantiate(GameManager.Instance.mainPlayer, transform.position, Quaternion.identity);
      Destroy(gameObject);
   }

   public void KillPlayer()
   {
      Destroy(gameObject);
   }

   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(transform.position, 2);
   }
}
