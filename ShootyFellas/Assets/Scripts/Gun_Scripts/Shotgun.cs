using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseGun
{
    public GameObject bsPointT;
    public GameObject bsPointB;
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
        if (currentAmmo > 0)
        {
            GameObject nextBullet = ammoReserve.GetNextBullet();
            if (nextBullet != null)
            {
                nextBullet.transform.position = bulletSpawnPoint.transform.position;
                nextBullet.transform.rotation = bulletSpawnPoint.transform.rotation;
                nextBullet.SetActive(true);

            }
            GameObject nextBullet2 = ammoReserve.GetNextBullet();
            if (nextBullet2 != null)
            {
                nextBullet2.transform.position = bsPointT.transform.position;
                nextBullet2.transform.rotation = bsPointT.transform.rotation;
                nextBullet2.SetActive(true);
            }
            GameObject nextBullet3 = ammoReserve.GetNextBullet();
            if (nextBullet3 != null)
            {
                nextBullet3.transform.position = bsPointB.transform.position;
                nextBullet3.transform.rotation = bsPointB.transform.rotation;
                nextBullet3.SetActive(true);
            }

            nextBullet.GetComponent<BaseProjectile>().OnSpawn();
            nextBullet2.GetComponent<BaseProjectile>().OnSpawn();
            nextBullet3.GetComponent<BaseProjectile>().OnSpawn();
            currentAmmo -= 3;
            lastFireTime = Time.time;

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
