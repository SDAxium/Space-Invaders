using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diagonalBulletScript : MonoBehaviour
{
    Vector2 initialVelocity;
    float minVelocity = -5f;
    Vector2 lastFrameVelocity;
    Rigidbody2D rb; 
    public bool left = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(left)
        {
            gameObject.transform.Rotate(new Vector3(0,0,-45), Space.Self);
            initialVelocity = new Vector2(-20f, -15f);
        }
        else
        {
            gameObject.transform.Rotate(new Vector3(0,0,45), Space.Self);
            initialVelocity = new Vector2(20f, -15f);
        }
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D enemyCheck = Physics2D.Raycast(transform.position, Vector2.down, 15f, LayerMask.GetMask("Enemy"));
        if(enemyCheck)
        {
            Destroy(gameObject);
        }
        lastFrameVelocity = rb.velocity;
        Destroy(gameObject, 15f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            bounce(col.contacts[0].normal);

           // rb.velocity = new Vector2(-velX, velY);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void bounce(Vector2 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector2.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
