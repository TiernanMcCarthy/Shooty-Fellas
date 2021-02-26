using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ammoPool;

    BaseGun thisGun;
    GameObject projectileToPool;


    // Update is called once per frame
    public void CreatePool()
    {
        Debug.Log("object " + this.name + " is pooling!!");
        thisGun = GetComponent<BaseGun>();
        projectileToPool = thisGun.thisProjectile;
        GameObject ammoHolder = GameObject.FindGameObjectWithTag("AmmoHolder" + thisGun.gunName);
        ammoPool = new List<GameObject>();
        GameObject temp;
        for(int i = 0; i < thisGun.maxAmmo; i++)
        {
            temp = Instantiate(projectileToPool);
            temp.SetActive(false);
            temp.transform.parent = ammoHolder.transform;
            ammoPool.Add(temp);
        }
    }

    public GameObject GetNextBullet()
    {
        for(int i =0; i < thisGun.maxAmmo; i++)
        {
            if(!ammoPool[i].activeInHierarchy)
            {
                return ammoPool[i];
            }
        }

        return null;
    }
}
