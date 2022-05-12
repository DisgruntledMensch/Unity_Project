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

    public HealthBarBehaviour Healthbar; 
    public float Hitpoints;

    [SerializeField]
    public float MaxHitPoints = 10;

    void Start()
    {
        Hitpoints = MaxHitPoints; 
        Healthbar.SetHealth(Hitpoints, MaxHitPoints);

        rb.AddForce(Force, ForceMode2D.Impulse);

        Physics2D.IgnoreCollision(enemy.GetComponent<CircleCollider2D>(),projectile.GetComponent<BoxCollider2D>());
    }

    public void TakeHit(float damage) 
    { 
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitPoints);

        if(Hitpoints <= 5)
        {
            Destroy(enemy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(GameOverText);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            MaxHitPoints -= 1;
        }
            if (MaxHitPoints <= 5)
        {
            Instantiate(SmallEnemyRight, enemyPositionRight.position, enemyPositionRight.rotation);
            explosion = Instantiate(explosion, spawnPoint.position, Quaternion.identity) as Rigidbody2D;
            Destroy(enemy);
            Instantiate(SmallEnemyLeft, enemyPositionLeft.position, enemyPositionLeft.rotation);
        }

        if (MaxHitPoints <= 0)
        {
            Instantiate(gameFinished);
            Time.timeScale = 0;
        }

    }
}
