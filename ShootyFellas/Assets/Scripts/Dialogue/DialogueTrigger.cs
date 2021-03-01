using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool canSkip = false;

    public GameObject skipPrompt;

    private void Start()
    {
        TriggerDialogue();
        StartCoroutine(firstSkip());
        //StartCoroutine(debugtrigger());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && canSkip)
        {
            canSkip = false;
            StartCoroutine(debugtrigger());
            skipPrompt.SetActive(false);
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator debugtrigger()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(5);
        canSkip = true;
        Debug.Log("can skip now");
        skipPrompt.SetActive(true);

    }

    IEnumerator firstSkip()
    {
        yield return new WaitForSeconds(5);
        skipPrompt.SetActive(true);
        canSkip = true;
    }
}
