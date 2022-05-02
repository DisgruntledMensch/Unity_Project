using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{


    public static int score = 0;
    
    public GameObject LevelComplete1Text;
    public GameObject LevelComplete2Text;
    public GameObject LevelComplete3Text;
    public GameObject LevelComplete4Text;
    public GameObject LevelComplete5Text;
    public GameObject BossfightText;


    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

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

        if (collision.gameObject.name == "SmallBallRight")
        {

            Debug.Log(score);
            score++;
        }

        if (collision.gameObject.name == "SmallBallLeft")
        {

            Debug.Log(score);
            score++;
        }

        if (score == 3 && sceneName == "Level1")
        {
            Instantiate(LevelComplete1Text);
            score = 0;
            Time.timeScale = 0;

        }

        else if (score == 3 && sceneName == "Level2")
        {
            Instantiate(LevelComplete2Text);
            score = 0;
            Time.timeScale = 0;

        }

        else if (score == 3 && sceneName == "Level3")
        {
            Instantiate(LevelComplete3Text);
            score = 0;
            Time.timeScale = 0;

        }

        else if (score == 4 && sceneName == "Level4")
        {
            Instantiate(LevelComplete4Text);
            score = 0;
            Time.timeScale = 0;

        }

        else if (score == 5 && sceneName == "Level5")
        {
            Instantiate(LevelComplete5Text);
            score = 0;
            Time.timeScale = 0;

        }

        else if (score == 10 && sceneName == "BossFight")
        {
            Instantiate(BossfightText);
            score = 0;
            Time.timeScale = 0;


        }
    }
}
