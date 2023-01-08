using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public int index = 0;

    public GameObject player;
    //public GameObject player1;

    public static int healthTrack = 3;

    public static bool levelTrack = false;


    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //print("Trigger Activated");

        if(trigger.tag == "Player")
        {
            healthTrack = player.GetComponent<PlayerHealthSystem>().currentHealth;
            levelTrack = player.GetComponent<PlayerController>().prevLevel;
            //print(healthTrack);
            //Destroy(player);
            SceneManager.LoadScene(index, LoadSceneMode.Single);
        }   

        
    }
    
}
