using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : Base_Upgrade
{
    public Auto_Fire fireScript;
    public Hand handScript;

    public List<GameObject> gunList;
    void Awake()
    {
        gunList = new List<GameObject>();
        fireScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Auto_Fire>();
        handScript = GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>();
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
        Spawner.WeaponChance -= 1;
        UpgradeGun();
    }
    public void UpgradeGun()
    {
        int temp = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().currentGun;
        if (temp != 4)
        {
            gunList[temp].SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().currentGun++;
            temp = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().currentGun;
            gunList[temp].SetActive(true);
            fireScript.currentGun = gunList[temp];
            handScript.currentGun = gunList[temp];
        }

    }
}
