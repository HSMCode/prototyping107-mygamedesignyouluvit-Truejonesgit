﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] meteors; 
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GameObject gameOverText;
    public Text scoreText;

    private bool restart;
    public bool gameOver;
    public int score;

    private void Start()
    { // Set score to '0', hide Game Over and Restart texts
        gameOver = false;
        restart = false;
        
       score = 0;
       UpdateScore();
       StartCoroutine (SpawnWaves());


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void LateUpdate()
    {
        if (restart == true)
        { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
            }
        }
    }

    // Obstacles spawn in waves
    IEnumerator SpawnWaves()
    {
        
        
            yield return new WaitForSeconds(startWait);
            while (true && gameOver == false)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);


            }
        
        
    }

    // Add score
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // Update score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    // Toggle Game Over and Restart screen 
    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        restart = true;
        
    }
}
