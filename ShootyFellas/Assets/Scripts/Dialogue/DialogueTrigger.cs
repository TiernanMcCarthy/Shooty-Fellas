using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool canSkip = false;

    private void Start()
    {
        TriggerDialogue();
        //StartCoroutine(debugtrigger());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && canSkip)
        {
            canSkip = false;
            StartCoroutine(debugtrigger());
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator debugtrigger()
    {
        yield return new WaitForSeconds(8);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        canSkip = true;
        Debug.Log("can skip now");
        
    }
}
