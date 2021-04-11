using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private List<string> dialogues = new List<string>();

    public float waitForNextLetter;
    
    public string dialogueForToWrite;

    public Text text;
    

    private static DialogueManager _instance;

    public static DialogueManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Dialogue Manager is Null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }


    public void SetDialogueToWrite(string dialogue)
    {
        if (dialogues.Count > 0)
        {
            dialogues.Add(dialogue);
            return;
        }
        else
        {
            dialogues.Add(dialogue);
        }
        gameObject.SetActive(true);
        StartCoroutine(WriteOneLetterAtATime());
    }

    public IEnumerator WriteOneLetterAtATime()
    {
        dialogueForToWrite = dialogues[0];
        
        
        for (int i = 0; i < dialogueForToWrite.Length; i++)
        {
            text.text = dialogueForToWrite.Substring(0, i);
            yield return new WaitForSeconds(waitForNextLetter);
        }

        float delay = dialogueForToWrite.Length * .07f;

        if (delay < 2)
            delay = 2;

        yield return new WaitForSeconds(delay);
        
        for (int i = 0; i < dialogueForToWrite.Length; i++)
        {
            text.text = dialogueForToWrite.Substring(0, dialogueForToWrite.Length - i - 1);
            yield return new WaitForSeconds(.01f);
        }
        
        dialogues.RemoveAt(0);
        
        if (dialogues.Count != 0)
        {
            StartCoroutine("WriteOneLetterAtATime");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
