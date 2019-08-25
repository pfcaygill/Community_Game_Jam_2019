using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public string areaType;
    void Start()
    {
        //when the game starts and not when it wakes, play the track for the room type looped
        FindObjectOfType<SingletonAudioController>().Play(areaType);
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
