using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBoss : MonoBehaviour
{
    public GameObject text;
    public GameObject Enemy;
    public GameObject gameFinished;

    public Vector2 smallBallForce;
    public Rigidbody2D rb;

    public Boss boss;
    void Start()
    {
        rb.AddForce(smallBallForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(text);
            Time.timeScale = 0;
        }

        if (collision.gameObject.tag == "Projectile")
        {

            boss.MaxHitPoints -= 1;

        }

        if(boss.MaxHitPoints == 0)
        {
            Instantiate(gameFinished);
            Time.timeScale = 0;
        }

    }
}