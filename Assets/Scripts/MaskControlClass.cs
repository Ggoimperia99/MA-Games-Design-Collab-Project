using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControlClass : MonoBehaviour
{
    public bool active;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            active = !active;
        }


        if (active == true)
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
