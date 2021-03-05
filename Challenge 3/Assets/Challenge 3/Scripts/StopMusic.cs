using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            audioSource.Stop();
        }
    }
}
