using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; set; }

    public static bool panel1Fixed { get; set; }
    public static bool panel2Fixed { get; set; }
    public static bool panel3Fixed { get; set; }
    public static bool SeaGrassRemoved { get; set; }
    public GameObject[] afterPanels;
    public GameObject[] afterPanelInteractable;

    private void Update()
    {
        if(panel1Fixed && panel2Fixed && panel3Fixed)
        {
            foreach (GameObject item in afterPanels)
            {
                item.GetComponent<Animator>().enabled = true;
            }
            foreach (GameObject item in afterPanelInteractable)
            {
                item.GetComponent<Collider>().enabled = true;
                item.GetComponent<Animator>().enabled = true;
            }

            panel1Fixed = false;
            panel2Fixed = false;
            panel3Fixed = false;
        }
    }
}
