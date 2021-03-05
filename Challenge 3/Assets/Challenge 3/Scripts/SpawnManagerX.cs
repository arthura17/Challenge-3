using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 2f;
    private float yPos;
    private int index;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    private void Update()
    {
        yPos = Random.Range(5, 15);
        index = Random.Range(0, 2);
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        if (!playerControllerScript.gameOver)
        {
            Vector3 spawnLocation = new Vector3(30, yPos, 0);
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
       
}
