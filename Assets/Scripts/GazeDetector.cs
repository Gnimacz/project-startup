using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GazeDetector : MonoBehaviour
{
    public bool hasFocus = false; //this variable will have to be updated with the tobii plugin
    bool currentFocusState = false;
    public float stateChangeCooldownTime = 1f;
    float timeSinceStateChange = 0f;
    public UnityEvent GotFocus;
    public UnityEvent LostFocus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStateChange += Time.deltaTime;

        if (timeSinceStateChange < stateChangeCooldownTime) return;

        if (currentFocusState != hasFocus) {
            currentFocusState = hasFocus;
            if (hasFocus) GotFocus.Invoke();
            else LostFocus.Invoke();
            timeSinceStateChange = 0f;
        }


    }
}
