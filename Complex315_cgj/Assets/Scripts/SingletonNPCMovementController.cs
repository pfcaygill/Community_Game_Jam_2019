using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingletonNPCMovementController : MonoBehaviour
{
    private UnityEvent invokeOnComplete;
    private Queue<NPCMovement> motions;

    public static SingletonNPCMovementController instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        motions = new Queue<NPCMovement>();
    }
    public void StartPath (NPCMovement move)
    {

    }
}
