using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    public GameObject text;
    public GameObject Enemy;

    public Vector2 smallBallForce;
    public Rigidbody2D rb;

    void Start()
    {
        rb.AddForce(smallBallForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(text);
            Destroy(GameObject.FindWithTag("Player"));
            Time.timeScale = 0;
        }

        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(Enemy);

        }

    }
}
