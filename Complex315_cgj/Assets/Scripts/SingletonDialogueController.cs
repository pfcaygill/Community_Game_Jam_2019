using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SingletonDialogueController : MonoBehaviour
{
    //UI
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private UnityEvent invokeOnComplete;
    private Queue<string> sentences;

    public static SingletonDialogueController instance;
    void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //Stop the singleton being destroyed
        DontDestroyOnLoad(gameObject);
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.charName;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }

    public void DisplayNext()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string next = sentences.Dequeue();
        dialogueText.text = next;
    }
    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        //once the dialogue closes we want to invoke the on finish event if it exists
        //and then empty out the event slot
        if (invokeOnComplete != null) {
            invokeOnComplete.Invoke();
            invokeOnComplete = null;
        }
    }
    public void BindEventToDialogueComplete(UnityEvent other)
    {
        invokeOnComplete = other;
    }
}
