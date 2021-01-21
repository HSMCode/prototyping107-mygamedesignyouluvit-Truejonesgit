using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    
    private GameController controllerScript;

    


    void Start()
    {
        controllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }

    


    void Update()
    {
        if (controllerScript.gameOver == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        
    }
}
