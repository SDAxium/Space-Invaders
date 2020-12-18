using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float velY;
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D enemyCheck = Physics2D.Raycast(transform.position, Vector2.down, 15f, LayerMask.GetMask("Enemy"));
        if(enemyCheck)
        {
            Destroy(gameObject);
        }
        rb.velocity = new Vector2(0, velY);
        Destroy(gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    void setSpeed(int val)
    {
        velY = val;
    }
}
