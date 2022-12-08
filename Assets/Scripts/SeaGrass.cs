using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaGrass : MonoBehaviour
{
    public Animator subAnimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("fish"))
        {
            subAnimator.SetTrigger("GrassRemoved");
            ProgressManager.SeaGrassRemoved = true;
            Destroy(gameObject);
        }
    }
}
