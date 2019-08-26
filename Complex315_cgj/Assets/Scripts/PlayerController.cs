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
    Vector2 currentPoint;
    [HideInInspector]
    bool readyForInput = true;
    void Start()
    {
        //Make sure our movement stays where the player has been put before the player is allowed to move
        destination = body.position;
    }
    void Update()
    {
        //Update checks inputs
        if (readyForInput)
        {
            currentPoint = body.position;
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
        switch(collision.gameObject.tag)
        {
            default: destination = currentPoint; break;
        }
    }
                                 
    
}
