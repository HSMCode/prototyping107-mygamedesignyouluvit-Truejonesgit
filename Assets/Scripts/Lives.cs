using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{

    public int lives;
    public GameObject zero;
    public GameObject one;
    public GameObject two;
    public GameObject three;

    
    void Start()
    {
        lives = 3;
    }

    
    void Update()
    {

        if (lives == 3)
        {
            three.gameObject.SetActive(true);
            two.gameObject.SetActive(false);
            one.gameObject.SetActive(false);
            zero.gameObject.SetActive(false);

        }
        else if (lives == 2)
        {
            three.gameObject.SetActive(false);
            two.gameObject.SetActive(true);
            one.gameObject.SetActive(false);
            zero.gameObject.SetActive(false);
        }
        else if (lives == 1)
        {
            three.gameObject.SetActive(false);
            two.gameObject.SetActive(false);
            one.gameObject.SetActive(true);
            zero.gameObject.SetActive(false);
        }
        else if (lives == 0)
        {
            three.gameObject.SetActive(false);
            two.gameObject.SetActive(false);
            one.gameObject.SetActive(false);
            zero.gameObject.SetActive(true);
        }
    }
}
