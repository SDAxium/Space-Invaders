using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform myTransform;
    private static bool increasing;
    private int min;
    private int max;
    private float x;
    private float y;
    private float z;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {   
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        increasing = true;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (increasing)
        {
            myTransform.position += new Vector3(0.01f, 0, 0) * speed;
        }
        else
        {
            myTransform.position += new Vector3(-0.01f, 0, 0) * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            increasing = !increasing;
        }  
    }   

    void notIncreasing()
    {
        increasing = !increasing;
    }
}
