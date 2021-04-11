using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   [TextArea(10, 10)]
   public string dialogue;

   public Collider2D collider;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<Player>())
      {
         DialogueManager.Instance.SetDialogueToWrite(dialogue);
      }
   }

   private void OnDrawGizmos()
   {
      Color c = Color.green;
      c.a = 0.4f;
      Gizmos.color = c;
      Gizmos.DrawSphere(transform.position, ((CircleCollider2D) collider).radius);

   }
}
