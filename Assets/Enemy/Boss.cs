using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject player;
    public GameObject enemy;
    public GameObject SmallEnemyRight;
    public GameObject SmallEnemyLeft;
    public GameObject projectile;
    public GameObject gameFinished;

    public Transform enemyPositionRight;
    public Transform enemyPositionLeft;

    public Vector2 Force;
    public Rigidbody2D rb;
    public Rigidbody2D explosion;
    public Transform spawnPoint;
    public GameObject LevelCompleteText;

    public int Health = 100;
    void Start()
    {
        rb.AddForce(Force, ForceMode2D.Impulse);

        //Physics2D.IgnoreCollision(enemy.GetComponent<CircleCollider2D>(),projectile.GetComponent<BoxCollider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(GameOverText);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            Health -= 10;
        }
            if (Health <= 50)
        {
            Instantiate(SmallEnemyRight, enemyPositionRight.position, enemyPositionRight.rotation);
            explosion = Instantiate(explosion, spawnPoint.position, Quaternion.identity) as Rigidbody2D;
            Destroy(enemy);
            Instantiate(SmallEnemyLeft, enemyPositionLeft.position, enemyPositionLeft.rotation);


        }

        if (Health <= 0)
        {
            Instantiate(gameFinished);
            Time.timeScale = 0;
        }


    }
}
