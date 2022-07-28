using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Vector3 direction;

    public float speed;
    public AudioClip sound;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();   
        if (sound == null){
            Debug.Log("Audio is null");
        }
        // AudioSource source = GetComponent<AudioSource>();
        // source.PlayOneShot(sound);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound); 
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = direction * speed;
    }

    public void SetDirection(Vector3 direction2)
    {
        direction = direction2;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovement john = collision.GetComponent<JohnMovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        
        if (john != null) john.Hit();

        if (grunt != null) grunt.Hit();

        DestroyBullet();
    }
}
