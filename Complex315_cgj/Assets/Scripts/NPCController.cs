using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    public string Requirement = null;
    public UnityEvent onRequirementMetTrigger;
    public UnityEvent onInteractionTriggers;
    [HideInInspector]
    private bool triggered = false;
    private bool requirementTriggered = false;

    public void Trigger()
    {
        //if there is a requirement, and it is met, and we have not allready done the thing, do the thing
        if (
            Requirement != null &&
            Requirement.Length > 0 &&
            SingletonGameStateController.instance.Check(Requirement) &&
            !requirementTriggered )
        {
            requirementTriggered = true;
            onRequirementMetTrigger.Invoke();
            return;
        }
        //else do the normal behavior
        if(!triggered)
            onInteractionTriggers.Invoke();
        triggered = true;
    }    
    public void SetTrigger(bool set)
    {
        triggered = set;
    }
    public void SetRequirementTrigger(bool set)
    {
        requirementTriggered = set;
    }
}
