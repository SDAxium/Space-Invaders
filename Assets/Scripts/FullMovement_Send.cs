using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMovement_Send : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    static bool sent = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(!sent)
        {
            player.SendMessage("FullMovement");
            sent = true;
        }
        
    }
}
