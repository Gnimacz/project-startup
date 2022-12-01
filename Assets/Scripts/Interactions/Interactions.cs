using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GazeDetector))]
public class Interactions : MonoBehaviour
{
    public void Scale(float scaleBy)
    {
        gameObject.transform.localScale = gameObject.transform.localScale * scaleBy;
    }
    public void MoveOnX(float amount)
    {
        transform.localPosition = transform.localPosition + new Vector3(amount, 0, 0);
    }
    public void MoveOnY(float amount)
    {
        transform.localPosition = transform.localPosition + new Vector3(0, amount, 0);
    }
    public void MoveOnZ(float amount)
    {
        transform.localPosition = transform.localPosition + new Vector3(0, 0, amount);
    }
    public void Animate(Animation anim)
    {
        anim.Play();
    }
}
