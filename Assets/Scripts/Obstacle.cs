using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameController gameController;
    private Lives lives;
    private AudioSource audioSource;
    public AudioClip explosion;
    public AudioClip hit;


    private void Start()
    {
        lives = GameObject.Find("spaceship_01").GetComponent<Lives>();
        audioSource = GetComponent<AudioSource>();
        


        // Get access to GameController script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }



    private void Update()
    {
        if (this.transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }




    void OnTriggerEnter2D(Collider2D other)
        {
        // Don't destroy inside boundary
            if (other.tag == "Boundary")
            {
                return;
            }
        
            //only gameOver if obstacle hits the player not another item
            if (!other.CompareTag("SpeedBoost"))
            {
  
                lives.lives--;
                if (lives.lives >= 0)
                {
                audioSource.PlayOneShot(hit, 0.3f);
                //play animation white frame (screenshake?)

                }
                else if (lives.lives <= 0)
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
}