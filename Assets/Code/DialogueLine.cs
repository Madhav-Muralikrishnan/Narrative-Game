using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueLine : DialogueSystem
{
    public string input;
    private TMP_Text textHolder;
    public float delay;
    public float interactionDelay;

    public Sprite characterSprite;
    public Image imageHolder;

    private bool done = false;

    public GameObject panel;
 

    private void Awake()
    {
        textHolder = GetComponent<TMP_Text>();
        textHolder.text = "";

        imageHolder.sprite = characterSprite;
        imageHolder.preserveAspect = true;
    }

    private void Update()
    { 
            if(DialogueHolder.write == true)
            {
                //panel.SetActive(true);
                if(done == false)
                {
                    StartCoroutine(WriteText(input, textHolder, delay /*, interactionDelay*/));
                    print("Starting corountine");
                    done = true;
                }
            }
            else
            {
                //panel.SetActive(false);
                textHolder.text = "";
                //StopCoroutine(WriteText(input, textHolder, delay /*, interactionDelay*/));
                done = false;
            }
            
    }


}
