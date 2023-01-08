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


    private void Awake()
    {
        textHolder = GetComponent<TMP_Text>();
        textHolder.text = "";

        imageHolder.sprite = characterSprite;
        imageHolder.preserveAspect = true;
    }

    private void Start()
    {
        StartCoroutine(WriteText(input, textHolder, delay /*, interactionDelay*/));
    }
}
