using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject player;
    public static bool hasKey = false; 
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, transform.position) < 0.5f)
        {
            gameObject.SetActive(false);
            hasKey = true;
            //print("hasKey: "+ hasKey);
        }

        
    }
}
