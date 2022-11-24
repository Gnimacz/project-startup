using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject spawner;
    public float minTimeBetweenSpawns = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
        Random.InitState((int)Time.realtimeSinceStartup);
    }
    private void Update()
    {
        transform.position = new Vector3(-8.85f, Random.Range(-2,3.5f), -4.06f);
    }

    IEnumerator SpawnAsteroid()
    {   
        Instantiate(spawner, gameObject.transform);
        yield return new WaitForSeconds(minTimeBetweenSpawns + Random.Range(0,2f));
        
        StartCoroutine(SpawnAsteroid());
    }
}
