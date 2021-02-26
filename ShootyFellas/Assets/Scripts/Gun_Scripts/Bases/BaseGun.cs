using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    //Gun class for other weapons to inherit from

    
    public SpriteRenderer gunsprite;

    [SerializeField]
    public ProjectilePool ammoReserve;

    public GameObject thisProjectile; 

    public float maxAmmo;
    public float currentAmmo;

    public float reloadTime;

    public string gunName; //so it can be added to the tag 

    public float lastFireTime;

    public bool canFire;

    public GameObject bulletSpawnPoint;
    public virtual void Start()
    {
        ammoReserve = this.GetComponent<ProjectilePool>();
        this.ammoReserve.CreatePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Fire()
    {

    }

    public virtual IEnumerator Reload(float time)
    {
        return null;
    }
}
