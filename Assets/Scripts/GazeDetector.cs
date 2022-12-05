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
    public bool activated = false;
    bool currentFocusState = false;
    public float stateChangeCooldownTime = 1f;
    public float delayBeforeTriggering = 0f;
    float timeSinceStateChange = 0f;
    [Space]
    public UnityEvent GotFocusInactive; // the player is focusing on the object but it can't activate yet
    public UnityEvent GotFocus; // the player is focusing on the object so it should get ready to activate
    public UnityEvent LostFocus; // the player is no longer focusing on the object
    public UnityEvent Activate; // the player focused on the object long enough to activate it
    [Space]
    public List<GazeDetector> dependancies;
    //this is for the tobii eye tracking position
    GazeAware gazeAwarenessComponent;

    // Start is called before the first frame update
    void Start()
    {
        gazeAwarenessComponent = GetComponent<GazeAware>();
        activated = false;
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

            if (hasFocus)
            {
                if (CheckDependancies()) GotFocus.Invoke();
                else GotFocusInactive.Invoke();
            }
            else LostFocus.Invoke();

            timeSinceStateChange = 0f;
        }

        if (hasFocus && timeSinceStateChange >= delayBeforeTriggering)
        {
            Activate.Invoke();
            activated = true;
        }

    }

    private bool CheckDependancies()
    {
        foreach (GazeDetector item in dependancies)
        {
            if (!item.activated) return false;
        }
        return true;
    }
}
