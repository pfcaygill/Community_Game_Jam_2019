using System;
using UnityEngine;

public class SingletonAudioController : MonoBehaviour
{
    public Sound[] sounds;
    public static SingletonAudioController instance;
    void Awake()
    {
        //Singleton
        if (instance == null)
            instance = this;
        else { Destroy(gameObject); return; }
        //Stop the singleton being destroyed
        DontDestroyOnLoad(gameObject);
        //build object for each sound to play the sound
        foreach (Sound s in sounds) { s.BindAudioSource(gameObject.AddComponent<AudioSource>()); }
    }
   
    public void Play(string name)
    {
        Sound clip = Array.Find(sounds, sound => sound.name == name);
        if (clip != null) clip.source.Play(); 
        Debug.Log("Sound triggered: "+((clip!=null)?clip.name:name+" not found"));
    }
}
