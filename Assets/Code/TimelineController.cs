using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{


    public PlayableDirector playd0;
    public float min0;
    public float min1;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playd0.time >= min0 && playd0.time <= min0 + 0.2)
        {
            playd0.playableGraph.GetRootPlayable(0).SetSpeed(0);
            //playd0.Pause(); 
        }

        if(playd0.time >= min1 && playd0.time <= min1 + 0.2)
        {
            //NPCScript.continueBool = false;
            //playd0.Pause();
            //print("Pausing");
            playd0.playableGraph.GetRootPlayable(0).SetSpeed(0);
            //NPCScript.continueBool = true;
        }
        print(NPCScript.continueBool);
        if(NPCScript.continueBool == true)
        {   
            //playd0.Resume();
            //print("resuming");
            playd0.playableGraph.GetRootPlayable(0).SetSpeed(1);
           
        }
        

    }
}
