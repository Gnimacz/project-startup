using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

[RequireComponent(typeof(GazeAware))]
public class LeverActivate : MonoBehaviour
{
    private GazeAware gazeAware;
    [SerializeField] GameObject handle;
    private float rotateion = 0f;

    void Start()
    {
        gazeAware = GetComponent<GazeAware>();
    }
    void Update()
    {
        if (gazeAware.HasGazeFocus)
        {
            rotateion++;
            handle.transform.rotation = Quaternion.Euler(-rotateion, -90,0);
        }
    }
}
