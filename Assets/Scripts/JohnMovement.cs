using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    private bool grounded;
    
    public float speed;
    public float jumpForce;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
       horizontal = Input.GetAxisRaw("Horizontal");
       Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
       if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
       {
           grounded = true;
       }
       else grounded = false;
       
       if (Input.GetKeyDown(KeyCode.W) && grounded)
       {
           Jump();
       }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
    
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
    }
}
