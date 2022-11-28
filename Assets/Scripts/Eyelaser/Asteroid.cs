using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

[RequireComponent(typeof(GazeAware))]
public class Asteroid : MonoBehaviour
{
    private GazeAware gazeAware;
    private GazePoint gazePoints;
    public Material gazeMaterial;
    public MeshRenderer gazeRenderer;
    [SerializeField] private float stareCounter = 0.0f;
    [SerializeField][Range(0.00f, 1.00f)] private float stareStep = 0.05f;
    [SerializeField] private float threshold = 2f;
    void Start()
    {
        transform.parent = null;
        gazeAware = GetComponent<GazeAware>();
        gazeMaterial = GetComponent<Material>();
        gazeRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gazeAware.HasGazeFocus)
        {
            //gazeMaterial.color = Color.red;
            gazeRenderer.material.color = new Color(1, 0, 0) * (stareCounter / 2);
            stareCounter += stareStep;
        }
        // Debug.Log(gazeAware.HasGazeFocus);
        if (stareCounter >= threshold)
        {
            Destroy(gameObject);
        }
    }
}
