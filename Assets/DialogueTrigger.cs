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
}
