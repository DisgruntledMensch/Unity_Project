using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private float RunSpeed = 2f;

    [SerializeField]
    private float WalkSpeed = 1f;

    public ProjectileMovement projectile;
    public Transform Shoot;

    public float Cooldown;
    float lastShot;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
            lastShot = Time.time;
            Instantiate(projectile, Shoot.position, transform.rotation);
        }

    }
}
