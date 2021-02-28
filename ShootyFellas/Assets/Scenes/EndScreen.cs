using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI MattsMurdered;

    public TextMeshProUGUI Profit;

    public EnemySpawner ME;
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
        }
        else if(ME.Score<0)
        {
            Profit.text = "Net Loss: " + ME.Score;
            Profit.color = Color.red;
        }

        MattsMurdered.text = "Innocent Bystanders Harmed: " + ME.MattsKilled;
    }

    public void Leave()
    {
        Application.Quit();
    }
}
