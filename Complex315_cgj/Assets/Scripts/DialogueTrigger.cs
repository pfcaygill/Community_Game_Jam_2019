using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue hiddenDialogue;
    //creates an event that can have listeners added to it in the unity editor
    public UnityEvent triggerOptionalEventsOnEnd;
    public UnityEvent hiddenTriggerOptionalEventOnEnd;
    public void Trigger()
    {
        Debug.Log("Triggering normal dialogue");
        if (triggerOptionalEventsOnEnd.GetPersistentEventCount() >= 1)
            SingletonDialogueController.instance.BindEventToDialogueComplete(triggerOptionalEventsOnEnd);
        SingletonDialogueController.instance.StartDialogue(dialogue);
    }
    public void TriggerHidden()
    {
        Debug.Log("Triggering hidden dialogue");
        if (hiddenTriggerOptionalEventOnEnd.GetPersistentEventCount() >= 1)
            SingletonDialogueController.instance.BindEventToDialogueComplete(hiddenTriggerOptionalEventOnEnd);
        SingletonDialogueController.instance.StartDialogue(hiddenDialogue);
    }
}
