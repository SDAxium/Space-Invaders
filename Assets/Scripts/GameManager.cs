using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
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
        Instantiate(Player, new Vector3(0, (float)-9.75,0), Quaternion.identity);
        xCord = -17;
        enemies.Add(new List<GameObject>{Instantiate(UFO, new Vector3(0, (float)9.5,0), Quaternion.identity)});

        // List<GameObject> yellows = new List<GameObject>();
        // for(int i = 0; i < 9; i++){
        //     yellows.Add(Instantiate(yellow, new Vector3(xCord,7,0), Quaternion.identity));
            
        //     if(i > 0)
            
        //     xCord += 3;
        // }
        // enemies.Add(yellows);

        // xCord = -17;
        // List<GameObject> pinks = new List<GameObject>();
        // for(int i = 0; i < 9; i++){
        //     pinks.Add(Instantiate(pink, new Vector3(xCord,3,0), Quaternion.identity));
        
        //     xCord += 3;
        // }
        // enemies.Add(pinks);

        // xCord = -17;
        // List<GameObject> oranges = new List<GameObject>();
        // for(int i = 0; i < 9; i++){
        //     oranges.Add(Instantiate(orange, new Vector3(xCord,5,0), Quaternion.identity));
            
        //     xCord += 3;
        // }
        // enemies.Add(oranges);

        // xCord = -17;
        // List<GameObject> greens = new List<GameObject>();
        // for(int i = 0; i < 12; i++){
        //     greens.Add(Instantiate(green, new Vector3(xCord,1,0), Quaternion.identity));
        //     xCord += 3;
        // }
        // enemies.Add(greens);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
