using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMat : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    public void ApplyMat1()
    {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = mat1;
    }

    public void ApplyMat2()
    {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = mat2;
    }

    private void Start()
    {
        Debug.Log(gameObject.GetComponent<MeshRenderer>().sharedMaterial);
    }
}
