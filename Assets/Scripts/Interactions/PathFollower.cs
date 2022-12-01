using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private int currentWaypoint = 0;


    private void Update()
    {
        foreach (Transform point in waypoints)
        {

        }
    }
}
