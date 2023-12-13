using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    private GameObject boss;

    public static bool activate = false;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        boss.GetComponent<Boss>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            print("Activating");
            boss.GetComponent<Boss>().enabled = true;
            activate = true;
        }
    }
}
