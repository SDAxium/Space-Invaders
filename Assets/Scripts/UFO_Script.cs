using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFO_Script : MonoBehaviour
{
    public GameObject blue;
    public Color currentState;
    public Color start;
    public Color suicide;
    public Color multishot;
    public Color tracking;
    public Color shield;
    public Color cancer;
    public Color enraged;

    private bool startOn = true;
    private bool suicideOn = false;
    private bool multishotOn = false;
    private bool trackingOn = false;
    private bool shieldOn = false;
    private bool cancerOn = false;
    private bool enragedOn = false;


    public Transform myTransform;
    Vector2 leftGun;
    Vector2 rightGun;
    Vector2 middleGun;
    public float maxHealth = 5000;
    public float currentHealth;
    private bool increasing;
    
    public float cooldown = 0.5f;
    private float x;
    private float y;
    private float z;
    public float speed;
    public GameObject bullet;
    public GameObject leftBullet;
    public GameObject rightBullet;
    Vector2 bulletPos;
    float fireRate = 0.1f;
    float nextShot = 0.0f;
    float nextSpawn = 0.0f;
    RaycastHit2D playerCheck;
    RaycastHit2D enemyCheck;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth/* (float)0.9*/;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        increasing = true;
        myTransform.position = new Vector3(x,y,z);

        currentState = start;
        gameObject.GetComponent<SpriteRenderer>().color = currentState;
    }

    // Update is called once per frame
    void Update()
    {
        playerCheck = Physics2D.Raycast(transform.position, Vector2.down, 30f, LayerMask.GetMask("Player"));
        enemyCheck = Physics2D.Raycast(transform.position - Vector3.down*3, Vector2.down, 30f, LayerMask.GetMask("Enemy"));
        leftGun = new Vector2(myTransform.position.x - (float)1.3, myTransform.position.y - (float)1.2);
        rightGun = new Vector2(myTransform.position.x + (float)1.3, myTransform.position.y - (float)1.2);
        middleGun = new Vector2(myTransform.position.x, myTransform.position.y - (float)1.2);
        movement();
        shoot();
        stateManager();
    }

    void stateManager()
    {
        //suicide state trigger
        if(currentHealth <= maxHealth*0.95)
        {
            currentState = suicide;
            startOn = false;
            suicideOn = true;
        }

        //multishot state trigger
        if(currentHealth <= maxHealth*0.9)
        {
            currentState = multishot;
            suicideOn = false;
            multishotOn = true;
        }

        //tracking state trigger
        if(currentHealth <= maxHealth*0.8)
        {
            currentState = tracking;
            multishotOn = false;
            trackingOn = true;
        }

        //shield state trigger
        if(currentHealth <= maxHealth*0.65)
        {
            currentState = shield;
            trackingOn = false;
            shieldOn = true;
        }

        //cancer state trigger
        if(currentHealth <= maxHealth*0.45)
        {
            currentState = cancer;
            shieldOn = false;
            cancerOn = true;
        }
        //enraged state trigger
        if(currentHealth <= maxHealth*0.1)
        {
            currentState = enraged;
            cancerOn = false;
            enragedOn = true;
        }

        gameObject.GetComponent<SpriteRenderer>().color = currentState;

        if(startOn)
        {
            cooldown = 0.3f;
            speed = 1;  
        }
        else if(suicideOn)
        {
            cooldown = 2.5f;
            fireRate = 0.5f;
            speed = (float)3;
            if(Time.time > nextSpawn)
            {
                nextSpawn = Time.time + cooldown;
                spawnBlue();
            }
        }
        else if(multishotOn)
        {
            fireRate = 0.4f;
            speed = 2f;
        }
        
    }

    void shoot()
    {
        if(startOn)
        {
            if(playerCheck && !enemyCheck)
            {
                if(Time.time > nextShot)
                {
                    nextShot = Time.time + cooldown;
                    GameObject bulletTemp = Instantiate(bullet, rightGun, Quaternion.identity);
                    GameObject bulletTemp2 = Instantiate(bullet, leftGun, Quaternion.identity);
                }
                
            }
        }
        else if(suicideOn)
        {
            if(Time.time > nextShot)
            {
                nextShot = Time.time + fireRate;
                Instantiate(bullet, middleGun, Quaternion.identity);
            }
                
        }
        else if(multishotOn)
        {
            if(Time.time > nextShot)
                {
                    nextShot = Time.time + fireRate;
                    leftGun = new Vector2(myTransform.position.x - (float)1.3, myTransform.position.y - (float)1.2);
                    rightGun = new Vector2(myTransform.position.x + (float)1.3, myTransform.position.y - (float)1.2);
                        
                    Instantiate(leftBullet, leftGun, Quaternion.identity);
                    Instantiate(rightBullet, rightGun, Quaternion.identity);   
                }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        Invoke("ResetColor", 0.3f);
        if(col.gameObject.tag == "Bullet")
        {
            currentHealth -= 20;
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
        
        if(col.gameObject.tag == "Wall")
        {
            increasing = !increasing;
        }
    }

    void spawnBlue()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        Invoke("ResetColor", 1f);
        float xCord = transform.position.x;
        for(int i = 0; i < 3;i++)
        {
            Instantiate(blue, new Vector3(xCord,y-3,0), Quaternion.identity);
            xCord += 3;
        }
    }

    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = currentState;
    }
    void movement()
    {
        if(increasing)
        {
            myTransform.position += new Vector3(0.01f* speed,0,0);
        }
        else
        {
            myTransform.position -= new Vector3(0.01f* speed,0,0) ;
        }
    }
}
