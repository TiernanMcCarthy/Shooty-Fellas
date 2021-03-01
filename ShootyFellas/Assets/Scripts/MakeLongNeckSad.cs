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

    public Dialogue gunExplain;
    public Dialogue gunExplain2;

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;
    public Dialogue fourthDialogue;
    public Dialogue fifthDialogue;
    public Dialogue sixthDialogue;
    public Dialogue seventhDialogue;
    public Dialogue eigthDialogue;

    public GameObject longNeck;
    public GameObject textBox;

    public Animator neckAnimator;

    bool hasDoneIntro = false;

    bool dumbFucking24 = false;
    void Start()
    {
        longNeck.SetActive(true);
        textBox.SetActive(true);
        currentlyTalking = true;
        StartTalking(gunExplain);
        StartCoroutine(FirstDialogueWait());
    }

    // Update is called once per frame
    void Update()
    {
        if(!currentlyTalking)
        {
            //Debug.Log("gamer");
            if(player.NumberOfMattsKilled == 0 && !hasDoneIntro)
            {
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                StartTalking(gunExplain2);
                hasDoneIntro = true;
            }
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
                StartTalking(thirdDialogue);
            }

            if (player.NumberOfMattsKilled >= 25 && player.NumberOfMattsKilled < 35 && !dumbFucking24)
            {
                dumbFucking24 = true;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Hat", true);
                StartTalking(fourthDialogue);
                
            }

            if (player.NumberOfMattsKilled >= 35 && player.NumberOfMattsKilled < 60 && lastIntRead != 35)
            {
                lastIntRead = 35;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                StartTalking(fifthDialogue);

            }

            if (player.NumberOfMattsKilled >= 60 && player.NumberOfMattsKilled < 95 && lastIntRead != 60)
            {
                lastIntRead = 60;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Hat", true);
                StartTalking(sixthDialogue);

            }
            if (player.NumberOfMattsKilled >= 95 && player.NumberOfMattsKilled < 160 && lastIntRead != 95)
            {
                lastIntRead = 95;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                neckAnimator.SetBool("Crying", true);
                StartTalking(seventhDialogue);

            }
            if (player.NumberOfMattsKilled >= 160 && lastIntRead != 160)
            {
                lastIntRead = 160;
                longNeck.SetActive(true);
                textBox.SetActive(true);
                currentlyTalking = true;
                StartTalking(eigthDialogue);

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

    IEnumerator FirstDialogueWait()
    {
        yield return new WaitForSeconds(5);
        longNeck.SetActive(false);
        textBox.SetActive(false);
        currentlyTalking = false;
        //manager.ClearText();
        //StartTalking(gunExplain2);
    }
}
