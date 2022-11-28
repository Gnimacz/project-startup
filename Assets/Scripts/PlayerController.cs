using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public float speed = 10.0f;
    public float distanceTreshold = 1.0f;
    public Vector2 inputPosition;
    Vector3 direction;

    /// <summary>
    /// Eye tracker related variables
    /// </summary>
    GazePoint lookingPoint = GazePoint.Invalid;
    private Vector3 historicPoint = new Vector3();
    private bool hasHistoricPoint = false;
    private bool isConnected = false;

    [Range(0.1f, 1.0f),
         Tooltip(
             "How heavy filtering to apply to gaze point bubble movements. 0.1f is most responsive, 1.0f is least responsive.")]
    public float filterSmoothingFactor = 0.98f;

    /// <summary>
    /// Smooths the tracking data to make it less jittery. Can be adjusted with the filterSmoothingFactor variable.
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private Vector3 Smoothify(Vector3 point)
    {
        if (hasHistoricPoint)
        {
            historicPoint = point;
            hasHistoricPoint = true;
        }

        var smoothedPoint = new Vector3(
            point.x * (1.0f - filterSmoothingFactor) + historicPoint.x * filterSmoothingFactor,
            point.y * (1.0f - filterSmoothingFactor) + historicPoint.y * filterSmoothingFactor,
            point.z * (1.0f - filterSmoothingFactor) + historicPoint.z * filterSmoothingFactor);

        historicPoint = smoothedPoint;

        return smoothedPoint;
    }

    void Start()
    {
        if (TobiiAPI.IsConnected)
        {
            isConnected = true;
        }
        else
        {
            isConnected = false;
            Debug.LogError("No Eye tracking device found. Switching to mouse input");
        }
    }

    void Update()
    {
        if (isConnected)
        {
            //Sensor input
            lookingPoint = TobiiAPI.GetGazePoint();
            Vector2 gazePointViewport = lookingPoint.Screen;
            inputPosition = Smoothify(gazePointViewport);//Input.mousePosition;
        }
        else
        {   
            inputPosition = Input.mousePosition;
        }

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(inputPosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (Vector3.Distance(hit.point, transform.position) < distanceTreshold) return;

            direction = hit.point - transform.position;
            direction.y = 0;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);
        }

    }
}
