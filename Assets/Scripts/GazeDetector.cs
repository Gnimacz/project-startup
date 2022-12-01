using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Tobii.Gaming;
[RequireComponent(typeof(GazeAware))]
[AddComponentMenu("GazeComponent")]
public class GazeDetector : MonoBehaviour
{
    public bool hasFocus = false; //this variable will have to be updated with the tobii plugin
    bool currentFocusState = false;
    public float stateChangeCooldownTime = 1f;
    public float delayBeforeTriggering = 0f;
    float timeSinceStateChange = 0f;
    [Space]
    public UnityEvent GotFocus;
    public UnityEvent LostFocus;
    //this is for the tobii eye tracking position
    GazeAware gazeAwarenessComponent;

    // Start is called before the first frame update
    void Start()
    {
        gazeAwarenessComponent = GetComponent<GazeAware>();
    }

    // Update is called once per frame
    void Update()
    {
        hasFocus = gazeAwarenessComponent.HasGazeFocus;
        timeSinceStateChange += Time.deltaTime;
        //Debug.Log(timeSinceStateChange);

        if (timeSinceStateChange < stateChangeCooldownTime) return;

        if (currentFocusState != hasFocus)
        {
            currentFocusState = hasFocus;
            if (delayBeforeTriggering <= 0f)
            {
                Debug.Log("Invoked something");
                if (hasFocus) GotFocus.Invoke();
                else LostFocus.Invoke();
            }
            else if(timeSinceStateChange < delayBeforeTriggering)
            {
                Debug.Log("Invoked something else");
                if (hasFocus) GotFocus.Invoke();
                else LostFocus.Invoke();
            }
            timeSinceStateChange = 0f;
        }


    }
}
