using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public AudioClip shoot;
    private Animator anim;

    [SerializeField]
    public float RunSpeed = 2f;

    [SerializeField]
    public float WalkSpeed = 1f;

    public ProjectileMovement projectile;
    public Transform Shoot;

    public float Cooldown;
    float lastShot;

    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = shoot;
    }

    void Update()
    {
        float input_x = Input.GetAxisRaw("Horizontal");

        bool isWalking = (Mathf.Abs(input_x)) > 0;

        anim.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            anim.SetFloat("input_x",input_x);
            transform.position += new Vector3(input_x, 0, 0).normalized * Time.deltaTime * WalkSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(input_x, 0, 0).normalized * Time.deltaTime * RunSpeed;
            }
            else
            {
                transform.position += new Vector3(input_x, 0, 0).normalized * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShot < Cooldown)
            {
                return;
            }
            GetComponent<AudioSource>().Play();
            lastShot = Time.time;
            Instantiate(projectile, Shoot.position, transform.rotation);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
        }
    }
}
