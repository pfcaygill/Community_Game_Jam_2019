using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    //Shell class for the AudioClip and settings for use in the inspector
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
    //Make the object set its own properties
    public void BindAudioSource(AudioSource toBind) {
        source = toBind;
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
    }
}
