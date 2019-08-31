using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public void TriggerOnce()
    {
        gameObject.GetComponent<Animator>().SetBool("CoinTaken", true);
    }
}
