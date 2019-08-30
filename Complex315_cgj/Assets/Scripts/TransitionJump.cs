using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionJump : MonoBehaviour
{
    public bool trigger = true;
    public float shiftx, shifty;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (trigger && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position += new Vector3(shiftx, shifty, 0);
            other.gameObject.GetComponent<PlayerController>().TeleportFix(new Vector2(shiftx, shifty));
            trigger = false;//need to turn themselves off after use
        }
    }
}
