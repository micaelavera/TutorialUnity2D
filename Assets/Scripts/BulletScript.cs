using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Vector3 direction;

    public float speed;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = direction * speed;
    }

    public void SetDirection(Vector3 direction2)
    {
        direction = direction2;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
