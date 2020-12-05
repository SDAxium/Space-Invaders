using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject UFO;
    public GameObject blue;
    public GameObject green;
    public GameObject pink;
    public GameObject orange;
    public GameObject yellow;

    float xCord;
    public List<List<GameObject>> enemies = new List<List<GameObject>>(); 
    // Start is called before the first frame update
    void Start()
    {
        xCord = -17;
        enemies.Add(new List<GameObject>{Instantiate(UFO, new Vector3(0, (float)9.5,0), Quaternion.identity)});

        List<GameObject> yellows = new List<GameObject>();
        for(int i = 0; i < 9; i++){
            yellows.Add(Instantiate(yellow, new Vector3(xCord,7,0), Quaternion.identity));
            
            if(i > 0)
            {
                yellows[i-1].gameObject.transform.parent = yellows[i-1].gameObject.transform;
            }
            xCord += 3;
        }

        xCord = -17;
        List<GameObject> oranges = new List<GameObject>();
        for(int i = 0; i < 10; i++){
            oranges.Add(Instantiate(orange, new Vector3(xCord,5,0), Quaternion.identity));
            
            if(i > 0)
            {
                oranges[i-1].gameObject.transform.parent = oranges[i-1].gameObject.transform;
            }
            xCord += 3;
        }

        xCord = -17;
        List<GameObject> pinks = new List<GameObject>();
        for(int i = 0; i < 10; i++){
            pinks.Add(Instantiate(pink, new Vector3(xCord,3,0), Quaternion.identity));
            
            if(i > 0)
            {
                pinks[i-1].gameObject.transform.parent = pinks[i-1].gameObject.transform;
            }
            xCord += 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
