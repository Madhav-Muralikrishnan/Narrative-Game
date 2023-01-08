using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCScript : MonoBehaviour
{
    public GameObject player;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;

    public GameObject button;

    public GameObject prompt;

    private bool promptBool = true;
    private float moveInput;

    public Sprite[] characterSprite;
    public Image imageHolder;

    public float playerActivationDistance;

    private float timer;

    public static bool continueBool = false;

    public bool flipEnabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //imageHolder.sprite = characterSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            if(flipEnabled == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if(player.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }


        if(Vector2.Distance(player.transform.position, transform.position) < playerActivationDistance)
        {
            //prompt.SetActive(true);
            if(promptBool == true)
            {    
                if(!dialoguePanel.activeInHierarchy)
                {
                    prompt.SetActive(true);
                    dialoguePanel.SetActive(true);
                    imageHolder.sprite = characterSprite[0];
                    StartCoroutine(Typing());
                    continueBool = false;
                }
            }

            if(dialogueText.text == dialogue[index])
            {
                button.SetActive(true);
                if(Input.GetKeyDown(KeyCode.R))
                {
                    NextLine();
                }
            }
        }
        else
        {
            prompt.SetActive(false);
            dialoguePanel.SetActive(false);
            zeroText();
        }

    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    } 

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
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
        button.SetActive(false);
        if(index < dialogue.Length - 1 )
        {
            index++;
            dialogueText.text = "";
            imageHolder.sprite = characterSprite[index];
            StartCoroutine(Typing());
            prompt.SetActive(true);
            continueBool = false;
        }
        else
        {
            prompt.SetActive(false);
            dialoguePanel.SetActive(false);
            zeroText();
            continueBool = true;
            promptBool = false;
        }
        
    }

    
}
