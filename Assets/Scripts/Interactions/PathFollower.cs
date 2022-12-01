using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


//[RequireComponent(typeof(PathCreator))]
public class PathFollower : MonoBehaviour
{
    //[SerializeField] Vector3[] waypoints;
    //Vector3 currentWaypointTransform;
    //private int currentWaypoint = 0;

    public bool canMove = false;
    [SerializeField] float speed = 10f;

    /// <summary>
    /// Sebastian Lague path creator variables
    /// </summary>
    [SerializeField] PathCreator creator;
    [SerializeField] EndOfPathInstruction endOfPathInstruction;
    float distanceTravelled = 0f;

    private void Update()
    {
        if (canMove)
        {
            WalkToWayPoint();
        }
        //if(currentWaypoint < waypoints.Length)
        //{
        //    if(currentWaypointTransform == null)
        //    {
        //        currentWaypointTransform = waypoints[currentWaypoint];
        //    }
        //    WalkToWayPoint();
        //}
    }

    private void WalkToWayPoint()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = creator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

        //Old
        //transform.forward = Vector3.RotateTowards(transform.forward, waypoints[currentWaypoint], speed * Time.deltaTime, 0.0f);
        //transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], speed * Time.deltaTime);

        //if(transform.position == currentWaypointTransform)
        //{
        //    currentWaypoint++;
        //    currentWaypointTransform = waypoints[currentWaypoint];
        //}
    }
}
