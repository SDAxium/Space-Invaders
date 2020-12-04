using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float velY = 20;
    float velX = 0f;
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name != "Ship")
        {
            Destroy(gameObject);
        }
    }
}
