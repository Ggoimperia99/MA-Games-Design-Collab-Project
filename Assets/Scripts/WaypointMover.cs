using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] private Waypoints myWaypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    [SerializeField] private float knockBackSpeed = 5f;
    [SerializeField] GameMan refGameMan;

    // Current waypoint we are moving to
    private Transform currentWaypoint;

    //bool checking if is moving
    public bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial position to first waypoint
        currentWaypoint = myWaypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // Set next waypoint target
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(refGameMan.myGameStates == GameMan.GameState.ActTWOExplore)
        {
            MoveToWaypoint();
        }
        else if(refGameMan.myGameStates == GameMan.GameState.ActTWOReveal)
        {
            SetStateWaypoint(refGameMan.ReturnStateIndex());
            MoveToWaypoint();
        }
        else if(refGameMan.myGameStates == GameMan.GameState.ActTHREE)
        {
            SetStateWaypoint(refGameMan.ReturnStateIndex());
            MoveToWaypoint();
        }
        else if(refGameMan.myGameStates == GameMan.GameState.ActFOURDilemma)
        {
            SetStateWaypoint(refGameMan.ReturnStateIndex());
            MoveToWaypoint();
        }
        else
        {
            return;
        }

        CheckMovement();
    }

    public void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        transform.LookAt(currentWaypoint);
    }

    public void MoveKnockBack()
    {
        transform.position = Vector3.back * Time.deltaTime * knockBackSpeed;
    }

    private void SetNextWaypoint()
    {
        currentWaypoint = myWaypoints.GetNextWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Pass a number that references the waypoint under the system, activate via refGameMan
    private void SetStateWaypoint(int wayPointIndex)
    {
        currentWaypoint = myWaypoints.GetAssociatedWayPoint(wayPointIndex);
        transform.LookAt(currentWaypoint);
    }

    // Set that movement bool to be referenced in other script
    private void CheckMovement()
    {
        if (Vector3.Distance(transform.position, currentWaypoint.position) >= distanceThreshold)
        {
            isWalking = true;
        }
        else if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            isWalking = false;
        }
    }
}
