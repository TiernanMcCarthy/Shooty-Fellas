using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Character playerScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScript.Health.ToString();
    }
}
