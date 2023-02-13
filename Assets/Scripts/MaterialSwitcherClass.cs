using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcherClass : MonoBehaviour
{
    public Material NormalMat; 
    public Material GlowingMat; 
    public Material CurrentMaterial; 


    void Start()
    {
        CurrentMaterial = this.GetComponent<Renderer>().material;
        CurrentMaterial = GlowingMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentMaterial != NormalMat)
            {
                CurrentMaterial = NormalMat;
            }
            else if (CurrentMaterial == NormalMat)
            {
                CurrentMaterial = GlowingMat;
            }
        }

        this.GetComponent<Renderer>().material = CurrentMaterial;
    }
}
