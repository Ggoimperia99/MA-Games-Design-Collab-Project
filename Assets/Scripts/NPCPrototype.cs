using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCPrototype : MonoBehaviour
{
    // Configuration Parameter
    [SerializeField] NPCSampleDialogue[] act1Dialogues;
    [SerializeField] NPCSampleDialogue[] act2ExploreDialogues;
    [SerializeField] NPCSampleDialogue[] act2RevealDialogues;
    [SerializeField] NPCSampleDialogue[] act4DilemmaDialogues;
    [SerializeField] GameMan refGameMan;
    [SerializeField] NPCAttackPoint myWeapon;

    // String to print out
    private string textToPrint;

    // Initial dialogue text to begin with
    private int act1Index = 0;
    private int act2ExploreIndex = 0;
    private int act2RevealIndex = 0;
    private int act4DilemmaIndex = 0;

    // Max dialogues in array
    private int maxDialogues;

    // Check if NPC is in combat
    private bool isFighting = false;

    // Reference components
    Animator myAnim;
    WaypointMover myMove;

    // Start is called before the first frame update
    void Start()
    {
        maxDialogues = act1Dialogues.Length;
        myAnim = GetComponent<Animator>();
        myMove = GetComponent<WaypointMover>();
    }

    // Update is called once per frame
    void Update()
    {
        DialogueBehaviour();
        CheckMaxDialogues();
        SetWalkAnimation();
        AttackPlayer();
        ReceiveDamage();
    }

    // Re-check max dialogues
    public void CheckMaxDialogues()
    {
        if(refGameMan.myGameStates == GameMan.GameState.ActONE)
        {
            maxDialogues = act1Dialogues.Length;
        }
        if(refGameMan.myGameStates == GameMan.GameState.ActTWOExplore)
        {
            maxDialogues = act2ExploreDialogues.Length;
        }
        if(refGameMan.myGameStates == GameMan.GameState.ActTWOReveal)
        {
            maxDialogues = act2RevealDialogues.Length;
        }
        if(refGameMan.myGameStates == GameMan.GameState.ActFOURDilemma)
        {
            maxDialogues = act4DilemmaDialogues.Length;
        }
        else
        {
            return;
        }
    }

    // Print the dialogues
    public void DialogueBehaviour()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // Check which array to use based on GameMan state
            if(refGameMan.myGameStates == GameMan.GameState.ActONE)
            {
                if (act1Index < maxDialogues)
                {
                    textToPrint = act1Dialogues[act1Index].dialogueText;
                    Debug.Log(textToPrint);
                    TriggerSetReaction(act1Dialogues[act1Index].animationStateName);
                    act1Index++;
                }
                else if (act1Index >= maxDialogues)
                {
                    return;
                }
            }

            if(refGameMan.myGameStates == GameMan.GameState.ActTWOExplore)
            {
                if (act2ExploreIndex < maxDialogues)
                {
                    textToPrint = act2ExploreDialogues[act2ExploreIndex].dialogueText;
                    Debug.Log(textToPrint);
                    TriggerSetReaction(act2ExploreDialogues[act2ExploreIndex].animationStateName);
                    act2ExploreIndex++;
                }
                else if (act2ExploreIndex >= maxDialogues)
                {
                    return;
                }
            }

            if (refGameMan.myGameStates == GameMan.GameState.ActTWOReveal)
            {
                if (act2RevealIndex < maxDialogues)
                {
                    textToPrint = act2RevealDialogues[act2RevealIndex].dialogueText;
                    Debug.Log(textToPrint);
                    TriggerSetReaction(act2RevealDialogues[act2RevealIndex].animationStateName);
                    act2RevealIndex++;
                }
                else if (act2RevealIndex >= maxDialogues)
                {
                    return;
                }
            }
            if(refGameMan.myGameStates == GameMan.GameState.ActFOURDilemma)
            {
                if(act4DilemmaIndex < maxDialogues)
                {
                    textToPrint = act4DilemmaDialogues[act4DilemmaIndex].dialogueText;
                    Debug.Log(textToPrint);
                    TriggerSetReaction(act4DilemmaDialogues[act4DilemmaIndex].animationStateName);
                    act4DilemmaIndex++;
                }
            }
            else
            {
                return;
            }
        }
        if (refGameMan.myGameStates == GameMan.GameState.ActTHREE)
        {
            Debug.Log("Prepare to die!");
            SetCombatMove(true);
            isFighting = true;
        }

        if (refGameMan.myGameStates == GameMan.GameState.ActFOURDilemma)
        {
            SetCombatMove(false);
            isFighting = false;
        }
    }

    // Toggle combat animation to attack player
    private void AttackPlayer()
    {
        if(isFighting)
        {
            if (Input.GetKeyUp(KeyCode.U))
            {
                myWeapon.AttackIsGo();
                Debug.Log("Die!");
            }
        }
    }

    // Process the damage and deal knockback to the NPC
    private void ReceiveDamage()
    {
        if (isFighting)
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                myMove.MoveKnockBack();
                Debug.Log("Ouch!");
            }
        }
    }

    // Trigger the walking animation if moving
    private void SetWalkAnimation()
    {
        if (myMove.isWalking)
        {
            myAnim.SetBool("npcWalking", true);
        }
        else if (!myMove.isWalking)
        {
            myAnim.SetBool("npcWalking", false);
        }
    }

    // Trigger the general reaction animation
    private void TriggerReactionGeneral()
    {
        myAnim.SetTrigger("npcReactGeneral");
    }

    // Trigger the state specific reaction animation
    private void TriggerSetReaction(string reactionName)
    {
        myAnim.SetTrigger(reactionName);
    }

    // Enables and disable combat movement animation
    private void SetCombatMove(bool combatSwitch)
    {
        myAnim.SetBool("npcCombatMove", combatSwitch);
    }

    // Trigger the idle animation after reactions
    public void SetIdle()
    {
        myAnim.SetTrigger("npcSetIdle");
    }
}
