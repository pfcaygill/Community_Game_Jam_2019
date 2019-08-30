using System;
using UnityEngine;
using UnityEngine.Audio;

public class SingletonAudioController : MonoBehaviour
{
    public Sound[] sounds;
    public static SingletonAudioController instance;
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
            return ;
        }
        DontDestroyOnLoad(gameObject);
        //build object for each sound to play the sound
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.BindAudioSource();
        }
    }
    void Start()
    {
        Play("Castle");
    }
   
    public void Play(string name)
    {
        Sound clip = Array.Find(sounds, sound => sound.name == name);
        if (clip != null && clip.source !=null) {
            clip.source.Play();
        } 
        Debug.Log("Sound triggered: "+
            ((clip!=null && clip.source != null) ?
                clip.name:
                name+" not found"));
    }
}
