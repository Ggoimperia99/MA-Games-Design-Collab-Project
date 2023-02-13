using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu]
public class NPCSampleDialogue : ScriptableObject
{
    public int dialogueIndex;

    [TextArea]
    public string dialogueText;

    public string animationStateName;
}
