using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    public UnityEvent onInteractionTriggers;
    [HideInInspector]
    private bool triggered = false;

    public void Trigger()
    {
        onInteractionTriggers.Invoke();
        triggered = true;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (
            other.gameObject.CompareTag("Player") &&
            Input.GetKey(KeyCode.Return) 
        ){
            Debug.Log("Interract");
            if (!triggered) { Trigger(); }
        }
    }
    public void SetTrigger(bool set)
    {
        triggered = set;
    }
}
