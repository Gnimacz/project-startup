using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class CameraLaserHandler : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private GazePoint gazePoint;
    public GameObject laserObject;

    private Vector3 historicPoint = new Vector3();
    private bool hasHistoricPoint = false;
    public float offset = 0f;

    [Range(0.1f, 1.0f),
         Tooltip(
             "How heavy filtering to apply to gaze point bubble movements. 0.1f is most responsive, 1.0f is least responsive.")]
    public float filterSmoothingFactor = 0.98f;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        gazePoint = TobiiAPI.GetGazePoint();
        Vector2 gazePointViewport = gazePoint.Viewport;
        Vector3 pointInWorld = new Vector3();
        pointInWorld = cam.ViewportToWorldPoint(new Vector3(gazePointViewport.x, gazePointViewport.y, cam.nearClipPlane + offset));
        laserObject.transform.position = Smoothify(pointInWorld);
    }

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
}
