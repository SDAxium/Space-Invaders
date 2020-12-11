using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFO_Script : MonoBehaviour
{
    public Transform myTransform;
    public int health;
    private bool increasing;
    private int min;
    private int max;
    private float x;
    private float y;
    private float z;
    public float speed;
    public GameObject bullet;
    Vector2 bulletPos;
    float fireRate = 0.1f;
    float nextShot = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        increasing = true;

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
            health -= 20;
            if(health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
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
        }
    }
}
