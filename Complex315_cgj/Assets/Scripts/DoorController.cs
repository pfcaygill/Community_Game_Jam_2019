using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Animator doorSprite;
    public BoxCollider2D doorTrigger;
    public bool openCurrently = false;
    public bool hidden = false;
    //the label of the scene we are going to transition to
    public string transitionToLabel;
    //the transform to apply when a player comes through this door
    public float xSpawn, ySpawn;

    void Start()
    {
        doorSprite.SetFloat("x", xSpawn);
        doorSprite.SetFloat("y", ySpawn);
        //modify the state of the box collider and the door sprite to match our expectations
        doorSprite.SetBool("isHidden", hidden);
        doorSprite.SetBool("isOpen", openCurrently);
        doorTrigger.isTrigger = openCurrently;
    }
    public void Trigger(bool open)
    {
        openCurrently = open;
        if (open) SingletonAudioController.instance.Play("Door_Open");
        doorSprite.SetBool("isOpen", openCurrently);
        doorTrigger.isTrigger = openCurrently;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && openCurrently)
        {
            SceneManager.LoadScene(transitionToLabel);
        }
    }
}
