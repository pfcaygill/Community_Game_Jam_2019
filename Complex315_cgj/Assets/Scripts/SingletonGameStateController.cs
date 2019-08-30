using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameStateController : MonoBehaviour
{
    public static SingletonGameStateController instance;
    private Dictionary<string, bool> state;
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
}
