using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public int sceneIndex;
    
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger Activated");

        if(trigger.tag == "Player")
        {
            print("Switching scene to " + sceneIndex);
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
