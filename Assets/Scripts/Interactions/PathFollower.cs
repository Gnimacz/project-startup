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
    }

    private void WalkToWayPoint()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = creator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation = creator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
    }

    public void IsAllowedToMove(bool canHeMove)
    {
        canMove = canHeMove;
    }
}
