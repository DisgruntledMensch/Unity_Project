using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioClip bounce;
    public AudioClip hit;
    private AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
     
        GetComponent<AudioSource>().Play();
        if (collision.gameObject.name == "Character")
        {
            audioSource.PlayOneShot(hit);
        }
       

        audioSource.PlayOneShot(bounce);
    }
}
