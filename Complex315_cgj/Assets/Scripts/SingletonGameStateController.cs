using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameStateController : MonoBehaviour
{
    public static SingletonGameStateController instance;

    //would normally want to use a dictionary, but am running out of time at this point
   
    public bool bucket, coin, pool = false;
    private string PreviousSceneName = null;

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
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable() { SceneManager.sceneLoaded += OnLoadCallback; }
    void OnDisable() { SceneManager.sceneLoaded -= OnLoadCallback; }
    //used to check the current state
    public bool Check(string upto)
    {
        switch (upto) {
            case "BUCKET": return instance.bucket;
            case "COIN": return instance.coin;
            case "POOL": return instance.pool;
            default: return false;
        }
    }
    
    //used to store new additions to the state
    public void Pass(string passed)
    {
        switch (passed)
        {
            case "BUCKET": instance.bucket = true;break;
            case "COIN": instance.coin = true; break;
            case "POOL": instance.pool = true; break;
            default: return;
        }
    }
    void OnLoadCallback(Scene scene, LoadSceneMode scenemode)
    {
        //if we have changed scenes from a room then move our player to the door they came from
        if (PreviousSceneName != null && PreviousSceneName != "Menu" && !"Menu".Equals(scene.name))
        {
            //finds all of our doors. we will use this to set the player position
            DoorController[] doors = FindObjectsOfType<DoorController>();
            PlayerController player = FindObjectOfType<PlayerController>();
            //start by finding the door that leads to the other level that we came from, this is the transform we want
            DoorController fromDoor = Array.Find(doors, door => PreviousSceneName.Equals(door.transitionToLabel));
            //modify the player transform, by combining the door transform and the transform modifiers
            Transform newPos = fromDoor.gameObject.transform;
            Vector2 vec = new Vector2(
                newPos.position.x + fromDoor.xSpawn,
                newPos.position.y + fromDoor.ySpawn
                );
            player.gameObject.transform.position = vec;
            player.Spawn(vec, fromDoor.xSpawn, fromDoor.ySpawn);

        }
        //set the previous scene to be this scene (should always happen)
        PreviousSceneName = scene.name;        
    }
}
