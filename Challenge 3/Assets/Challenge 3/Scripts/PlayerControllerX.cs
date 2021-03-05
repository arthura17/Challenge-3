using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    //for the movement of the balloon
    public float floatForce;
    private float gravityModifier = 1f;
    private Rigidbody playerRb;
    private float upperLimit = 14f;

    //when the balloon hits the ground force
    private float boingForce = 12;

    //particl systems for fx on money and bomb
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    //AudioSource & clips
    private AudioSource playerAudio;
    public AudioClip blipSound;
    public AudioClip boomSound;
    public AudioClip boingSound;


    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && !(transform.position.y > upperLimit))
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(boomSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(blipSound, 1.0f); 
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * boingForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(boingSound, 1.0f);
        }
    }

}
