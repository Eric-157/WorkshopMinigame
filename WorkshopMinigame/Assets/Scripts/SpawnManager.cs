using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject car;

    public float spawnDelay;
    public float lowerRange;
    public float upperRange;

    public bool isSpawner = false;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        yield return new WaitForSeconds(spawnDelay);
        while (true)
        {
            SpawnCar();
            float randomInterval = Random.Range(lowerRange, upperRange);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    void SpawnCar()
    {
        if (isSpawner == true)
        {
            Vector3 spawnPos = new Vector3(-13f, 1.25f, z);
            Instantiate(car, spawnPos, car.transform.rotation);
        }
    }
}
