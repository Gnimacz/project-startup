using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubble;
    public Transform spawnerPos;

    public void SpawnBubble()
    {
        Instantiate(bubble, spawnerPos);
    }
}
