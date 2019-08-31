using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTrigger : MonoBehaviour
{
    public void Pass(string stage)
    {
        SingletonGameStateController.instance.Pass(stage);
    }
}
