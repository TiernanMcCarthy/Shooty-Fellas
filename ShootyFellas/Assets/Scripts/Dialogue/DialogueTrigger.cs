using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public DialogueManager manager;

    private void Start()
    {
        TriggerDialogue();
        StartCoroutine(debugtrigger());
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator debugtrigger()
    {
        yield return new WaitForSeconds(5);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        StartCoroutine(debugtrigger());
    }
}
