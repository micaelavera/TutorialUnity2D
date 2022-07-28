using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float horizontal;
    private bool isGrounded;
    private float lastShoot;
    
    public float speed;
    public float jumpForce;

    public GameObject BulletPrefab;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       horizontal = Input.GetAxisRaw("Horizontal");

       if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
       else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

       animator.SetBool("running", horizontal != 0.0f);

       // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

       if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
       {
           isGrounded = true;
       }
       else isGrounded = false;
       
       if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
       {
           Jump();
       }

       if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.25f)
       {
           Shoot();
           lastShoot = Time.time;
       }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        //Quaternion.identity -> rotacion 0
        // transform.position -> centro del player John + offset
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
      
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
    }
}
