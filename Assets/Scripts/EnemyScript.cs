using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform myTransform;
    public int health;
    public bool increasing;
    private int min;
    private int max;
    private float x;
    private float y;
    private float z;
    public float speed;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        myTransform.position = new Vector3(x,y,z);
    }

    // Update is called once per frame
    void Update()
    {
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
            health -= 50;
            if(health <= 0)
            {
                Destroy(gameObject);
                // for(int i = 0; i < gm.enemies.Count; i++)
                // {
                //     for(int j = 0; j < gm.enemies[i].Count; i++)
                //     {
                //         if(gm.enemies[i][j].gameObject.name == this.name)
                //         {
                //             Debug.Log(name);
                //         }
                //     }
                // }
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
            float x = 0;
            while( x < 2f)
            {
                myTransform.position += new Vector3(0,(float)-.01f,0);
                x += .01f;
            }
        }

        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
