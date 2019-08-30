using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameStateController : MonoBehaviour
{
    public static SingletonGameStateController instance;

    private Dictionary<string, bool> state;
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
        //track everything between scenes
        state = new Dictionary<string, bool>();
    }
    void OnEnable() { SceneManager.sceneLoaded += OnLoadCallback; }
    void OnDisable() { SceneManager.sceneLoaded -= OnLoadCallback; }
    //used to check the current state
    public bool Check(string upto)
    {
        bool passed = false;
        state.TryGetValue(upto, out passed);
        return passed;
    }
    
    //used to store new additions to the state
    void UpdateState(string passed)
    {
        state.Add(passed, true);       
    }

    //used to load into the state from a file
    void LoadState()
    {

    }
    //used to save the state from a file
    void SaveState()
    {

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
