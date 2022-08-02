using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;

    private float lastShoot;
    private int health = 3;

    void Update()
    {
      if (John == null) return;
      Vector3 direction = John.transform.position - transform.position;
      if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
      else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

      float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

      if (distance < 1.0f && Time.time > lastShoot + 0.25f)
      {
          Shoot();
          lastShoot = Time.time;

      }
    }

    private void Shoot()
    {
        // Debug.Log("Shoot");
         Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        //Quaternion.identity -> rotacion 0
        // transform.position -> centro del player John + offset
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        health = health - 1;
        if (health == 0) Destroy(gameObject);
    }
}
