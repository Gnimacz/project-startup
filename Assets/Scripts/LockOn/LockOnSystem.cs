using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class LockOnSystem : MonoBehaviour
{
    public GameObject gazedObject;
    public GameObject referenceObject;
    private GameObject currentObject;
    public GameObject previousFrameObject;

    public float stareCounter = 0;
    public float threshold = 1.5f;

    // Angular speed in radians per sec.
    public float speed = 1.0f;

    private Queue<GameObject> gazedQueue = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float singleStep = speed * Time.deltaTime;
        gazedObject = TobiiAPI.GetFocusedObject();
        if (gazedObject != null)
        {
            if (gazedObject != previousFrameObject)
            {
                previousFrameObject = gazedObject;
                stareCounter = 0;
            }
        }



        while (gazedQueue.Count > 0 && currentObject == null)
        {
            GameObject toDestroy = gazedQueue.Dequeue();
            currentObject = toDestroy;
            if (currentObject != null)
            {
                StartCoroutine(DestroyObject(currentObject));
            }
        }

        // Determine which direction to rotate towards
        Vector3 targetDirection = Vector3.zero;
        if (currentObject != null)
        {
            targetDirection = currentObject.transform.position - transform.position;
            Vector3 newRotation = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
        }
    }

    private void FixedUpdate()
    {
        if (gazedObject == previousFrameObject)
        {
            stareCounter += 0.1f;
        }
        if (stareCounter > threshold)
        {
            if (!gazedQueue.Contains(gazedObject))
            {
                if (gazedObject != null)
                {
                    gazedObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
                gazedQueue.Enqueue(gazedObject);
                //currentObject = gazedObject;
            }
        }
    }

    IEnumerator DestroyObject(GameObject asteroid)
    {
        asteroid.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1.2f);
        currentObject = null;
        Destroy(asteroid);
    }
}
