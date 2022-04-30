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

    public GameObject LevelCompleteText;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Force, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(GameOverText);
            Destroy(player);
            Time.timeScale = 0;
        }

        if(collision.gameObject.tag == "Projectile")
        {
            Instantiate(SmallEnemyRight, enemyPositionRight.position, enemyPositionRight.rotation);
            Destroy(enemy);

            Instantiate(SmallEnemyLeft, enemyPositionLeft.position, enemyPositionLeft.rotation);

        }

    }
}