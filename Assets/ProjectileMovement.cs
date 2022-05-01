using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed;
    public AudioClip split;
    private AudioSource audioSource;

    void Start()
    {
     audioSource = GetComponent<AudioSource>();
     audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, Time.deltaTime * MoveSpeed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy") { audioSource.PlayOneShot(split); }
       
    }

}
