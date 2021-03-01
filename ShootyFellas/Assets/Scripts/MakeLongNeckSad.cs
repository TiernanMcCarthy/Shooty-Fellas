using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeLongNeckSad : MonoBehaviour
{
    bool currentlyTalking = false;

    int lastIntRead = 0;
    public Character player;

    public DialogueManager manager;


    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;
    public Dialogue fourthDialogue;
    public Dialogue fifthDialogue;
    public Dialogue secretDialogue;

    public GameObject longNeck;
    public GameObject textBox;

    public Animator neckAnimator;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!currentlyTalking)
        {
            //Debug.Log("gamer");
            if (player.NumberOfMattsKilled == 1 && lastIntRead != 1)
            {
                Debug.Log("gamer2");
                lastIntRead = 1;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                StartTalking(firstDialogue);
            }

            if(player.NumberOfMattsKilled >= 5 && player.NumberOfMattsKilled < 10 && lastIntRead != 5)
            {
                lastIntRead = 5;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                StartTalking(secondDialogue);
            }

            if (player.NumberOfMattsKilled >= 15 && player.NumberOfMattsKilled < 30 && lastIntRead != 15)
            {
                lastIntRead = 15;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Hat", true);
                StartTalking(thirdDialogue);
            }

            if (player.NumberOfMattsKilled >= 35 && player.NumberOfMattsKilled < 50 && lastIntRead != 30)
            {
                lastIntRead = 30;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Crying", true);
                StartTalking(fourthDialogue);
                
            }

            if (player.NumberOfMattsKilled >= 50 && player.NumberOfMattsKilled < 95 && lastIntRead != 50)
            {
                lastIntRead = 50;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Crying", true);
                StartTalking(fifthDialogue);

            }

            if (player.NumberOfMattsKilled >= 95 && lastIntRead != 95)
            {
                lastIntRead = 95;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Crying", true);
                StartTalking(secretDialogue);

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
        currentlyTalking = false;
    }
}
