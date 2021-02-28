using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun_UI : MonoBehaviour
{
    public List<GameObject> spriteList;

    public BaseGun currentGun;

    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI maxAmmoText;

    int currentGunSprite = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmoText.text = currentGun.currentAmmo.ToString();
        maxAmmoText.text = currentGun.maxAmmo.ToString();
    }

    public void NextSprite()
    {
        if(currentGunSprite != 4)
        {
            spriteList[currentGunSprite].SetActive(false);
            currentGunSprite++;
            spriteList[currentGunSprite].SetActive(true);
        }
  
    }
}
