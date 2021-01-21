using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameController gameController;
    private Lives livesScript;
    private AudioSource audioSource;
    public AudioClip explosion;
    public AudioClip hit;
    public int scoreValue;

    private void Start()
    {
        livesScript = GameObject.Find("spaceship_01").GetComponent<Lives>();
        audioSource = GetComponent<AudioSource>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }



    void Update()
    {
        if (this.transform.position.y < -10f) // destroy obstacle when its below the screen
        {
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
    
        livesScript.lives--;




        if (livesScript.lives >= 0)
        {

            audioSource.PlayOneShot(hit, 0.3f);

        }
        else if (livesScript.lives <= 0)
        {


            // Add explosion particle upon death, stop game, destroy obstacle and player, access GameOver-function
            Instantiate(playerExplosion, transform.position, transform.rotation);
            audioSource.PlayOneShot(explosion, 0.5f);
            Destroy(other.gameObject, 0.05f);
            Destroy(gameObject, 1f);
            gameController.GameOver();


        }


    }
}