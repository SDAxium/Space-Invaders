using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Transform myTransform;
    public GameObject bullet;
    Vector2 bulletPos;
    public int health = 400;
    public float fireRate = 0.3f;
    static float nextShot = 0.0f;
    float speed;
    void Start()
    {
        speed = 0.05f;
        myTransform.position = new Vector2(0, (float)-9.75);   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myTransform.position += new Vector3(speed*-1f,0,0);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myTransform.position += new Vector3(speed* 1f,0,0);
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && Time.time > nextShot)
        {
            nextShot =  Time.time + fireRate;
            fire();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyBullet")
        {
            health -= 30;
        }

        if(col.gameObject.tag == "Enemy")
        {
            health -= 50;
        }
        
        if(health <= 0)
        {

            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void fire()
    {
        float bpY = myTransform.position.y + (float)1.5;
        float bpX = myTransform.position.x;
        bulletPos = new Vector2(bpX,bpY);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
}
