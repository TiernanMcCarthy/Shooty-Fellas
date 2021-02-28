using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeLongNeckSad : MonoBehaviour
{
    bool currentlyTalking = false;

    int lastIntRead = 0;
    public EnemySpawner spawner;

    public DialogueManager manager;


    public Dialogue firstDialogue;

    public GameObject longNeck;
    public GameObject textBox;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!currentlyTalking)
        {
            //Debug.Log("gamer");
            if (spawner.MattsKilled == 1 && lastIntRead != 1)
            {
                Debug.Log("gamer2");
                lastIntRead = 1;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                StartTalking(firstDialogue);
            }
        }
     
    }

    void StartTalking(Dialogue thisDialogue)
    {
        manager.StartDialogue(thisDialogue);
        StartCoroutine(WaitForDialogue());
    }
    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(5);
        longNeck.SetActive(false);
        textBox.SetActive(false);
    }
}
