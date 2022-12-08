using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    MeshRenderer randerer;
    public Material shader;
    public Material oldMat;
    public int blinkTime = 3;
    public bool canBlink = true;

    void Start()
    {
        randerer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(canBlink && (int)Time.fixedTime % blinkTime == 0)
        {
            randerer.sharedMaterial = shader;
        }
        else
        {
            randerer.sharedMaterial = oldMat;
        }
        
    }

    public void StopBlink()
    {
        canBlink = false;
    }
}
