using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SingletonDialogueController : MonoBehaviour
{
    //UI
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator MovementAnimator;
    public Animator CharacterAnimator;
    private UnityEvent invokeOnComplete = null;
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
        sentences = new Queue<string>();
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialogue (Dialogue dialogue)
    {
        CharacterAnimator.SetBool("IsFriend", "F(r)iend".Equals( dialogue.charName));
        MovementAnimator.SetBool("isOpen", true);
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
        SingletonAudioController.instance.Play("Select");
        string next = sentences.Dequeue();
        dialogueText.text = next;
    }
    public void EndDialogue()
    {
        MovementAnimator.SetBool("isOpen", false);
        //once the dialogue closes we want to invoke the on finish event if it exists
        //and then empty out the event slot
        if (invokeOnComplete != null) {
            Debug.Log("Invoking on dialogue complete");
            invokeOnComplete.Invoke();
            invokeOnComplete = null;
        }
    }
    public void BindEventToDialogueComplete(UnityEvent other)
    {
        invokeOnComplete = other;
    }
}
