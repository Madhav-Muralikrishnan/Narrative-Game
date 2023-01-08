using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(dialogueSequence());
    }

    private IEnumerator dialogueSequence()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Deactivate();
            transform.GetChild(i).gameObject.SetActive(true);
            print(transform.GetChild(i).GetChild(1).GetComponent<DialogueLine>().input);
            yield return new WaitUntil(() => transform.GetChild(i).GetChild(1).GetComponent<DialogueLine>().finished == true);
        }
        gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
