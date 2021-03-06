﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Fire : MonoBehaviour
{
    public GameObject currentGun;
    public float defaultFireRate = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - currentGun.GetComponent<BaseGun>().lastFireTime >= currentGun.GetComponent<BaseGun>().timeBetweenShots && currentGun.GetComponent<BaseGun>().canFire)
        {
            currentGun.GetComponent<BaseGun>().Fire();
        }
    }
}
