using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector3 moveDir = new Vector3(0,2f,0);

    public void Pop()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position = transform.position + moveDir * Time.deltaTime;
    }
    private void Awake()
    {
        transform.parent = null;
    }
}
