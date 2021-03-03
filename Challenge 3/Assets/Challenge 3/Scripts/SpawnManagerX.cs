using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PrawnsObject", spawnDelay, spawnInterval);
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        Vector3 spawnLocation = new Vector3(30, 10, 0);
        int index = 0;

        Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
    }
}
