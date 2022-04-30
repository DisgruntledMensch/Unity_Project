using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{


    private static int score = 0;
    
    public GameObject LevelCompleteText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {

            Debug.Log(score);
            score++;
        }

        if (collision.gameObject.name == "SmallBallRight(Clone)")
        {

            Debug.Log(score);
            score++;
        }

        if (collision.gameObject.name == "SmallBallLeft(Clone)")
        {

            Debug.Log(score);
            score++;
        }

        if (score == 3)
        {
            Instantiate(LevelCompleteText);
            Time.timeScale = 0;
        }

    }
}
