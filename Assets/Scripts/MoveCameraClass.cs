using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraClass : MonoBehaviour
{
    public Transform cameraPosition;
    void Start()
    {
        
    }

    void Update()
    {
        //Camera follows gameobject childed to player to control eye position of player
        transform.position = cameraPosition.position;   
    }
}
