using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    public enum GameState { Freeze, ActONE, ActTWOExplore, ActTWOReveal, ActTHREE, ActFOURDilemma, ActFOURSave, ActFOURExpell, End };
    [Header("State Machine")]
    public GameState myGameStates;
    public bool freezeGame;

    // Assigning an index to the game state for waypoint reference
    public int stateIndex;


    [Header("State Change Bools")]
    public bool WomanIntroDialogueDONE;
    public bool allObjectsFound;
    public bool WomanCoffinDialogueDONE;
    public bool WomanDEFEATED;
    public bool SAVEWoman;
    public bool EXPELLWoman;
    public bool WomanENDDialogueDONE;

    [SerializeField] WaypointMover nPCMovement;

    void Start()
    {
        
    }


    void Update()
    {
        StateChanges();
    }

    void StateChanges()
    {
        if (myGameStates == GameState.Freeze)
        {
            //game is frozen to prevent weird start
            freezeGame = true;

            //FREEZE --> ActONE
            //bool disables on (insert) trigger, state changes
        }
        else if (myGameStates == GameState.ActONE)
        {
            //Womam greets player, introduces situation

            //ActONE --> ActTWOexplore
            if (WomanIntroDialogueDONE)
            {
                //changes after woman has completed her introduction dialogue
                myGameStates = GameState.ActTWOExplore;
            }

            stateIndex = 0;
        }
        else if (myGameStates == GameState.ActTWOExplore)
        {
            //player wanders around house, finds and examines objects

            //ActTWOexplore --> ActTWOreveal
            if (allObjectsFound)
            {
                //changes after all objects (besides coffin) have been examined
                myGameStates = GameState.ActTWOReveal;
            }

            stateIndex = 1;
        }
        else if (myGameStates == GameState.ActTWOReveal)
        {
            //player has found all objects in house, examines coffin

            //ActTWOreveal --> ActTHREE
            if (WomanCoffinDialogueDONE)
            {
                //changes after woman coffin dialogue has been completed
                myGameStates = GameState.ActTHREE;
            }

            stateIndex = 2;
        }
        else if (myGameStates == GameState.ActTHREE)
        {
            //player fights woman
            if (WomanDEFEATED)
            {
                // player has defeated the woman
                myGameStates = GameState.ActFOURDilemma;
            }

            stateIndex = 2;
        }
        else if(myGameStates == GameState.ActFOURDilemma)
        {
            //player has defeated woman, chooses to save her
            //ActTHREE --> ActFOURsave
            if (SAVEWoman)
            {
                //changes after woman has been defeated
                myGameStates = GameState.ActFOURSave;
            }

            //player has defeated woman, chooses to expell her
            //ActTHREE --> ActFOURexpell
            if (EXPELLWoman)
            {
                //changes after woman has been defeated
                myGameStates = GameState.ActFOURExpell;
            }

            stateIndex = 3;
        }
        else if (myGameStates == GameState.ActFOURSave)
        {
            //woman dialogue

            //ActFOURsave --> End
            if (WomanENDDialogueDONE)
            {
                //changes after woman save dialogue has been completed
                myGameStates = GameState.End;
            }
        }
        else if (myGameStates == GameState.ActFOURExpell)
        {
            //woman dialogue

            //ActFOURexpell --> End
            if (WomanENDDialogueDONE)
            {
                //changes after woman save dialogue has been completed
                myGameStates = GameState.End;
            }
        }
        else if (myGameStates == GameState.End)
        {
            //end screens, credits
            //freeze bool turns back on?

            //End --> potential reset????
            //load scene?
        }
    }


    // Return the assigned state index number
    public int ReturnStateIndex()
    {
        return stateIndex;
    }
}
