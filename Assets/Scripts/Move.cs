using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speedX = 0.02f;
    [SerializeField] private float speedY = 0.0f;
    [SerializeField] private float speedZ = 0.0f;
    private void FixedUpdate()
    {
        transform.position += new Vector3(speedX, speedY, speedZ);
    }

    private void Start()
    {
        transform.parent = null;
    }
}
