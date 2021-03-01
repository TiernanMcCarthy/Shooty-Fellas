using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI MattsMurdered;

    public TextMeshProUGUI Profit;

    public EnemySpawner ME;

    public UnityEngine.UI.Image Neck;

    public Sprite Happy;

    public Sprite Middling;

    public Sprite Sad;

    // Start is called before the first frame update
    void Start()
    {
        ME = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ME.Score>0)
        {
            Profit.text = "Net Profit: " + ME.Score;
            Profit.color = Color.green;
            Neck.sprite = Happy;
        }
        else if(ME.Score<0)
        {
            Profit.text = "Net Loss: " + ME.Score;
            Profit.color = Color.red;

            if(ME.Score<-1000)
            {
                Neck.sprite = Sad;
            }
            else
            {
                Neck.sprite = Middling;
            }
        }

        MattsMurdered.text = "Innocent Bystanders Harmed: " + ME.MattsKilled;

        
    }

    public void Leave()
    {
        Application.Quit();
    }
}
