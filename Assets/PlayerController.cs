using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public float speed = 10.0f;
    public float distanceTreshold = 1.0f;
    public Vector2 inputPosition;
    Vector3 direction;

    void Start()
    {
        
    }

    void Update()
    {
        //replace this with sensor input
        inputPosition = Input.mousePosition;

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(inputPosition);
        
        if (Physics.Raycast(ray, out hit)) {
            
            if (Vector3.Distance(hit.point, transform.position) < distanceTreshold) return;

            direction = hit.point - transform.position;
            direction.y = 0;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);
        }

    }
}
