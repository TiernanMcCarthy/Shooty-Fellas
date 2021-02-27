using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseGun
{
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
        if(currentAmmo > 0)
        {
            GameObject nextBullet = ammoReserve.GetNextBullet();
            if (nextBullet != null)
            {
                nextBullet.transform.position = bulletSpawnPoint.transform.position;
                nextBullet.transform.rotation = this.transform.rotation;
                nextBullet.SetActive(true);
                nextBullet.GetComponent<BaseProjectile>().OnSpawn();
                currentAmmo -= 1 * GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().AmmoMultiplier;
                lastFireTime = Time.time;
            }

        }
        else
        {
            StartCoroutine(Reload(reloadTime * GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().ReloadMultiplier));
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
}
