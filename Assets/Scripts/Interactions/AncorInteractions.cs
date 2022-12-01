using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncorInteractions : MonoBehaviour
{
    public Animation cameraAnim;
    Animation ancorAnim;

    // Start is called before the first frame update
    void Start()
    {
        ancorAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoDown()
    {
        cameraAnim.Play("CameraDown");
        ancorAnim.Play("AncorDown");
    }

    public void Shake()
    {
        gameObject.transform.localScale = 1f;
    }

    public void StopShaking()
    {
        gameObject.transform.localScale = 0.4f;
    }
}
