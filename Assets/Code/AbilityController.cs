using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityController : MonoBehaviour
{
    public bool castBool = false;
    public bool strikeBool = false;
    public bool defBool = false;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(dialogueText.text == dialogue[index])
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                NextLine();
            }

            if(castBool == true)
            {
                
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    Boss.cast = true;
                    print("Boss cast " + Boss.cast);
                }
            }

            if(strikeBool == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Boss.strk = true;
                    print("Boss strike " + Boss.strk);
                }
            }

            if(defBool == true)
            {
                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Boss.def = true;
                    print("Boss def " + Boss.def);
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        
        
            if(collider.tag == "Player")
            {
                if(!dialoguePanel.activeInHierarchy)
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());
                    //print("truing");
                }
                
            

            }
        
    } 

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter ;
            yield return new WaitForSeconds(wordSpeed);
        }

        
    } 

    private void NextLine()
    {
        if(index < dialogue.Length - 1 )
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            dialoguePanel.SetActive(false);
            zeroText();
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
}
