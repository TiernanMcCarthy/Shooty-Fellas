using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : Base_Upgrade
{
    public Auto_Fire fireScript;
    public Hand handScript;

    public List<GameObject> gunList;
    public int currentGun = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UpgradeGun();
        }
    }

    public override void OnTouchPlayer()
    {
        UpgradeGun();
    }
    public void UpgradeGun()
    {
        if(currentGun != 4)
        {
            gunList[currentGun].SetActive(false);
            currentGun++;
            gunList[currentGun].SetActive(true);
            fireScript.currentGun = gunList[currentGun];
            handScript.currentGun = gunList[currentGun];
        }

    }
}
