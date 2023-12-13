using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour
{
    public GameObject player;
    public GameObject nPC;
    private bool done = false;
    public static bool write = false;

    private int index;

    private GameObject[] npcImageArray;
    private GameObject[] buttonArray;

    private GameObject npcImage;
    private GameObject button;

    private int forEachIndex0 = 0;
    private int forEachIndex1 = 0;

    public float distance = 2f;
    /*private void Awake()
    {
        StartCoroutine(dialogueSequence());
    }*/
    
    void Start()
    {
        /*foreach(var obj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if(obj.name == "NPCImage")
            {
                npcImageArray[forEachIndex0] = obj;
                forEachIndex0++;
            }

            if(obj.name == "Button")
            {
                buttonArray[forEachIndex1] = obj;
                forEachIndex1++;
            }

        }*/

    }

    void Update()
    {
        npcImage = GameObject.Find("NPCImage");
        button = GameObject.Find("Button");
        

            if(Vector2.Distance(player.transform.position, nPC.transform.position) < distance)
            {
                ActivateForDialogue();
                GetComponent<Image>().enabled = true;
                if(done == false)
                {
                    StartCoroutine(dialogueSequence());
                    done = true;
                    write = true;
                }
            }
            else
            {
                //panel.SetActive(false);
                //Deactivate();
                DeactivateForDialogue();
                GetComponent<Image>().enabled = false;
                done = false;
                write = false;
            }   
        
    }

    private IEnumerator dialogueSequence()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            index = i;
            //print(index + " :index");
            Deactivate();
            transform.GetChild(i).gameObject.SetActive(true);
            print(transform.GetChild(i).GetChild(1).GetComponent<DialogueLine>().input);
            yield return new WaitUntil(() => transform.GetChild(i).GetChild(1).GetComponent<DialogueLine>().finished == true);
        }
        //gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void DeactivateForDialogue()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == index)
            {
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                continue;
            }
            transform.GetChild(i).gameObject.SetActive(false);
            //print(transform.GetChild(i) + " transform");
            transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
        }
    }
    private void ActivateForDialogue()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == index)
            {
                transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
