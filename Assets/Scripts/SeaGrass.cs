using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaGrass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            Debug.Log("FISHs");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            Debug.Log("FISHdfghms");
            Destroy(gameObject);
        }
    }
}
