using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    public GameObject text;
    public GameObject Enemy;

    public Vector2 smallBallForce;
    public Rigidbody2D rb;
    public Rigidbody2D explosion;

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
            explosion = Instantiate(explosion, gameObject.transform.position, Quaternion.identity) as Rigidbody2D;
            Destroy(Enemy);

        }

    }
}
