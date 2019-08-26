using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //creates an event that can have listeners added to it in the unity editor
    public UnityEvent triggerOptionalEventsOnEnd;
    public void Trigger()
    {
        if (triggerOptionalEventsOnEnd.GetPersistentEventCount() >= 1)
            SingletonDialogueController.instance.BindEventToDialogueComplete(triggerOptionalEventsOnEnd);
        SingletonDialogueController.instance.StartDialogue(dialogue);
    }

}
