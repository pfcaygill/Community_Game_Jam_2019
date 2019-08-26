using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string charName;
    [TextArea(3,6)]
    public string[] sentences;
}
