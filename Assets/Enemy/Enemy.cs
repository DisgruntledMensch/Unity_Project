using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject player;
    public GameObject enemy;
    public GameObject SmallEnemyRight;
    public GameObject SmallEnemyLeft;

    public Transform enemyPositionRight;
    public Transform enemyPositionLeft;

    public Vector2 Force;
    public Rigidbody2D rb;
    public Rigidbody2D explosion;
    public Transform spawnPoint;
    public GameObject LevelCompleteText;

     
    void Start()
    {
        rb.AddForce(Force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
              Instantiate(GameOverText);
        }

        if(collision.gameObject.tag == "Projectile")
        {
            Instantiate(SmallEnemyRight, enemyPositionRight.position, enemyPositionRight.rotation);
            Destroy(enemy);
            explosion = Instantiate(explosion, gameObject.transform.position, Quaternion.identity) as Rigidbody2D;
            Instantiate(SmallEnemyLeft, enemyPositionLeft.position, enemyPositionLeft.rotation);


        }

    }
}
