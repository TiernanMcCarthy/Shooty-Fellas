using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAMAS : BaseGun
{


    public float burstGap;
    public int currentShot = 1;
    public override void Start()
    {
        base.Start();
        //ammoReserve.CreatePool();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Fire()
    {
        currentShot = 1;
        if (currentAmmo >= 3)
        {
            GameObject nextBullet = ammoReserve.GetNextBullet();
            if (nextBullet != null)
            {
                nextBullet.transform.position = bulletSpawnPoint.transform.position;
                nextBullet.transform.rotation = this.transform.rotation;
                nextBullet.SetActive(true);
                nextBullet.GetComponent<BaseProjectile>().OnSpawn();
                currentAmmo -= 3 * GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().AmmoMultiplier;
                lastFireTime = Time.time;
            }
            currentShot++;
            StartCoroutine(BurstFire());


        }
        else
        {
            StartCoroutine(Reload(reloadTime * GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().ReloadMultiplier));
        }

    }

    void BurstShot()
    {
        GameObject nextBullet = ammoReserve.GetNextBullet();
        if (nextBullet != null)
        {
            nextBullet.transform.position = bulletSpawnPoint.transform.position;
            nextBullet.transform.rotation = this.transform.rotation;
            nextBullet.SetActive(true);
            nextBullet.GetComponent<BaseProjectile>().OnSpawn();
        }
        if(currentShot == 2)
        {
            currentShot++;
            StartCoroutine(BurstFire());
        }
    }

    public override IEnumerator Reload(float time)
    {
        canFire = false;
        lastFireTime = Time.time;
        yield return new WaitForSeconds(time);
        currentAmmo = maxAmmo;
        canFire = true;

    }

    IEnumerator BurstFire()
    {
        yield return new WaitForSeconds(burstGap);
        BurstShot();
        Debug.Log("yoooooooooooooooo");
    }

    
}
