using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    
    public GameObject panelToTurnOn;
    public GameObject player;

    public bool isBrown = false;
    public bool isGreen = false;
    public bool isBlue = false;

    public static bool staticIsBrown = false;
    public static bool staticIsGreen = false;
    public static bool staticIsBlue = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(KeyScript.hasKey == true)
        {
            panelToTurnOn.SetActive(true);
            //panelToTurnOff.SetActive(false);

            if(isBrown == true)
            {
                staticIsBrown = true;
            }
            
            if(isGreen == true)
            {
                staticIsGreen = true;
            }

            if(isBlue == true)
            {
                staticIsBlue = true;
            }
        }    
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            print("Brown: " + staticIsBrown + " Green: " + staticIsGreen + " Blue: " + staticIsBlue);
        }

        if(Vector2.Distance(player.transform.position, transform.position) < 2f)
        {
            KeyScript.hasKey = false;
            print("giving key");
        }
    }
}
