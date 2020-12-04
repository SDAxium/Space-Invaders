using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform myTransform;
     public GameObject bullet;
    Vector2 bulletPos;
    float fireRate = 0.1f;
    float nextShot = 0.0f;
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
            myTransform.position += new Vector3(speed*-1,0,0);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myTransform.position += new Vector3(speed,0,0);
        }

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && Time.time > nextShot)
        {
            nextShot =  Time.time + fireRate;
            fire();
        }
    }

    void fire()
    {
        bulletPos = myTransform.position;
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
}
