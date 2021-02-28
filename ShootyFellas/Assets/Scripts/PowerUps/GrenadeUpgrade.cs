using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeUpgrade : Base_Upgrade
{
    public SpawnGrenade spawnScript;

    public List<GameObject> grenadeList;
    void Awake()
    {
        grenadeList = new List<GameObject>();
        spawnScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnGrenade>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpgradeGrenade();
        }
    }

    public override void OnTouchPlayer()
    {
        Spawner.ReloadUpgrade -= 1;
        UpgradeGrenade();
    }
    public void UpgradeGrenade()
    {
        int temp = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().currentGrenade;
        if (temp != 2)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().currentGrenade++;
            spawnScript.defaultGrenade = grenadeList[temp];
        }

    }
}
