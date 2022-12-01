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
            rotateion += 0.2f;
            if (handle.transform.rotation.x > 306f)
            {
                Debug.Log("A");
                rotateion = 160f;
            }
            Debug.Log(handle.transform.rotation.eulerAngles.x);
            handle.transform.rotation = Quaternion.Euler(-rotateion, 0, 0);
        }
    }
}
