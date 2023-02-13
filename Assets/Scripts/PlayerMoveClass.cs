using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveClass : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizInput;
    float vertInput;

    Vector3 moveDir;

    Rigidbody rigBod;

    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
        rigBod.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        //checks if player is standing on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //calls input void and speed control void
        MyInput();
        SpeedControl();

        //adds drag to rigBod so that player doesn't slide like on ice --> drag is removed if player is not grounded
        if (grounded)
        {
            rigBod.drag = groundDrag;
        }
        else
        {
            rigBod.drag = 0;
        }
    }

    private void MyInput()
    {
        //all player input in HERE!
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //applies force in correct direction for movement
        moveDir = orientation.forward * vertInput + orientation.right * horizInput;
        rigBod.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl()
    {
        //stops player from sliding everywhere! Stops when input stops
        Vector3 flatVel = new Vector3(rigBod.velocity.x, 0f, rigBod.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rigBod.velocity = new Vector3(limitedVel.x, rigBod.velocity.y, limitedVel.z);
        }
    }
}
