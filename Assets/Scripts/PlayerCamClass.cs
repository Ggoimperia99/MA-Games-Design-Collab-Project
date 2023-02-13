using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamClass : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float XRotation;
    float YRotation;
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Basic camera movement
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        YRotation += mouseX;
        XRotation -= mouseY;


        //Clamps rotation so that player can't look backwards without rotating player gameobject
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);
        orientation.rotation = Quaternion.Euler(0, YRotation, 0);
    }
}
