using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Color OGcolor;
    public Color damageColor;
    public GameObject bullet;
    Vector2 bulletPos;
    public Transform myTransform;
    public int health;
    public bool increasing;
    private int min;
    private int max;
    private float x;
    private float y;
    private float z;
    public float speed;
    public float fireRate = 2.0f;
    float nextShot = 0.0f;
    public int value;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        myTransform.position = new Vector3(x,y,z);
        gameObject.GetComponent<SpriteRenderer>().color = OGcolor; 
    }

    // Update is called once per frame
    void Update()
    {   
        RaycastHit2D playerCheck = Physics2D.Raycast(transform.position, Vector2.down, 15f, LayerMask.GetMask("Player"));
        RaycastHit2D enemyCheck = Physics2D.Raycast(transform.position, Vector2.down, 15f, LayerMask.GetMask("Enemy"));
        
        if(playerCheck)
        {
            if(transform.position.y < 0)
            {
                if(Time.time > nextShot)
                {
                    nextShot = Time.time + fireRate;
                    shoot();
                }
            }
            
                            
        }
        
       if(increasing)
        {
            myTransform.position += new Vector3(0.01f,0,0) * speed;
        }
        else
        {
            myTransform.position -= new Vector3(0.01f,0,0) * speed;
        } 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetColor", 0.3f);
          
            health -= 50;
            if(health <= 0)
            {
                GameObject SK = GameObject.Find("ScoreKeeper");
                ScoreScript score = SK.GetComponent<ScoreScript>();
                score.AddScore(value);
                Destroy(gameObject);
            }
        }
        
        if(col.gameObject.tag == "Wall")
        {
            if(increasing == true)
            {
                increasing = false;
            }
            else 
            { 
                increasing = true;
            }
            float y = 0;
            while( y < 2f)
            {
                myTransform.position += new Vector3(0,(float)-.01f,0);
                y += .01f;
            }
        }

        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void shoot()
    {
        float bpY = myTransform.position.y - (float).5;
        if(gameObject.name.Contains("Yellow"))
        {
            bpY = myTransform.position.y - (float)1.25;
        }
        float bpX = myTransform.position.x;
        bulletPos = new Vector2(bpX,bpY);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }

    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = OGcolor;
    }
}
