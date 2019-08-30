using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTrigger : MonoBehaviour
{
    public string hoverText;

    public void OnMouseEnter()
    {
        SingletonHoverController.instance.ShowHover(hoverText);
    }
    public void OnMouseExit()
    {
        SingletonHoverController.instance.HideHover();
    }
}
