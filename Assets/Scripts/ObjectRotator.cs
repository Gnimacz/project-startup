using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public Vector2 gazePoint;
    public float maxRotationAngle = 5f;
    public float rotationSmoothing = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gazePoint = Input.mousePosition;

        Vector2 centerPoint = new Vector2(Screen.width/2, Screen.height/2);
        Vector2 gazeFromCenter = gazePoint - centerPoint;

        Quaternion targetRotation = Quaternion.Euler(
            Map(gazeFromCenter.y, -centerPoint.y, centerPoint.y, -maxRotationAngle, maxRotationAngle),
            Map(gazeFromCenter.x, -centerPoint.x, centerPoint.x, maxRotationAngle, -maxRotationAngle), 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,  Time.deltaTime * rotationSmoothing);

    }

    /// <summary>
	/// maps a variable to a new range of values
	/// </summary>
	/// <param name="value"></param>
	/// <param name="old_min"></param>
	/// <param name="old_max"></param>
	/// <param name="new_min"></param>
	/// <param name="new_max"></param>
	/// <returns></returns>
	public static float Map(float value, float old_min, float old_max, float new_min, float new_max, bool noClamp = false)
	{
		if (!noClamp)
			value = Mathf.Clamp(value, old_min, old_max);
		return new_min + (value - old_min) * (new_max - new_min) / (old_max - old_min);
	}
}
