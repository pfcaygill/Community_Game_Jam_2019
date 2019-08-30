using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingletonHoverController : MonoBehaviour
{

    public TextMeshProUGUI hoverText;
    public Animator MoveAnimator;

    public static SingletonHoverController instance;
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
    }
    public void ShowHover(string hover)
    {
        hoverText.SetText(hover);
        MoveAnimator.SetBool("Showing", true);
    }
    public void HideHover()
    {
        MoveAnimator.SetBool("Showing", false);
    }
}

