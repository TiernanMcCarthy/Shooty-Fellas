﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadShorten : Base_Upgrade
{
    // Start is called before the first frame update
    Character player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            OnTouchPlayer();
        }
    }

    public override void OnTouchPlayer()
    {
        player.ReloadMultiplier = player.ReloadMultiplier / 2;
    }
}