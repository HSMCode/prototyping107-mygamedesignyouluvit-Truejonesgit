using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {

        controller = GameObject.Find("GameController").GetComponent<GameController>();
        GetComponent<Rigidbody>();
    }

    // Move obstacles automatically
    void Update()
    {
        if (controller.gameOver == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        
    }
}
