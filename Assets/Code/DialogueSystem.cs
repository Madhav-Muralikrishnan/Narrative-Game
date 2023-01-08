using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public bool finished;

    protected IEnumerator WriteText(string input, TMP_Text textHolder, float delay /*, float interactionDelay*/)
    {
        for(int i = 0;i < input.Length; i++)
        {
            print("length = " + input.Length);
            textHolder.text += input[i];
            print(input);
            print(textHolder.text);
            yield return new WaitForSeconds(delay);
        }
        //yield return new WaitForSeconds(interactionDelay);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
        finished = true;
    }

}
