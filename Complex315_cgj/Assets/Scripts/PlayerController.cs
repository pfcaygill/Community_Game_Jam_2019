using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D body;
    public Animator animator;

    [Range(5f, 15f)]
    public float Speed = 5f;

    [HideInInspector]
    Vector2 destination;
    [HideInInspector]
    Vector2 currentPoint; //we know this should never be 0,0 as our grid is offset
    [HideInInspector]
    bool readyForInput = true;
    bool interacting = false;
    bool beginInteraction = false;
    void Start()
    {
        //SPECIAL SPAWN BEHAVIOR
        if (!Vector2.zero.Equals(currentPoint))
        {
            Debug.Log(currentPoint);
            destination = currentPoint;
            body.MovePosition(currentPoint);
            return;
        }
        //Make sure our movement stays where the player has been put before the player is allowed to move
        destination = body.position;
    }
    void Update()
    {
        //Update checks inputs
        if (readyForInput && !interacting)
        {
            currentPoint = new Vector2( body.position.x, body.position.y);
            destination.x += Input.GetAxisRaw("Horizontal");
            if (destination.x == currentPoint.x) destination.y += Input.GetAxisRaw("Vertical"); //enforce no diagonals
            if (destination.x != currentPoint.x)
            {
                animator.SetFloat("x", destination.x - currentPoint.x);
                animator.SetFloat("y", 0);//reset other direction
            }
            if (destination.y != currentPoint.y)
            {
                animator.SetFloat("y", destination.y - currentPoint.y);
                animator.SetFloat("x", 0);
            }                
        }
        //and sets us ready to move again if the difference of position is less than a threshhold
        readyForInput = (body.position.x == destination.x && body.position.y == destination.y);
        animator.SetBool("moving",!readyForInput);
        //due to some double triggering issues:
        if (Input.GetKeyDown(KeyCode.Return)) {
            beginInteraction = true;
        }
    }
    void FixedUpdate()
    {
        body.MovePosition(
            Vector2.MoveTowards(
                body.position,
                destination,
                Time.deltaTime * Speed
            )
        );
    }
    //called when the player bumps into an object
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("not trapped");
        switch(collision.gameObject.tag)
        {
            default:
                destination = currentPoint;
                Debug.Log("reset");
                break;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (
            other.gameObject.CompareTag("NPC") && beginInteraction
        )
        {
            beginInteraction = false;
            other.gameObject//select the npc
                .GetComponent<NPCController>()//get the script component
                .Trigger(); //trigger the script behavior
        }
    }
    public void Spawn(Vector2 other, float xanim, float yanim) {
        //spawns you out of a door
        currentPoint = other;
    }

    public void TeleportFix(Vector2 other)
    {
        destination += other;
    }
}
