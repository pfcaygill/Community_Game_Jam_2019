using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Animator animator;
    public void Trigger()
    {
        Debug.Log("credits");
        animator.SetBool("BeginCredits",true);
        animator.SetBool("CreditsPlaying",true);
        animator.SetBool("CreditsFinished",true);
    }
    void Start()
    {
        SingletonAudioController.instance.Stop("Castle");
    }
}
