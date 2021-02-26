using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateObject
{
    public float EngageDistance = 5.0f;

    public float Range = 6.0f; //ADJUST

    public float Speed = 5.0f;

    public float AMMO = 8;

    public float MaxAMMO = 8;

    public bool Reloading = false;

    public float ReloadingTime = 4;

    public float FireTime = 1.0f;
    private float LastFire = 0;

    public Vector3 MoveToLocation;

    public State CurrentState;

    public Board Map;

    public CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = new Seek();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.Execute(this);
    }

    public bool Move()
    {
        CC.Move((MoveToLocation - transform.position).normalized * Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, MoveToLocation) < 2.0f)
        {
            return true;
        }
        Debug.Log(Vector3.Distance(MoveToLocation, transform.position));

        return false;
    }

    public void Fire()
    {
        if(Time.time-LastFire>=FireTime)
        {
            Debug.Log("Bang Bang");
            AMMO--;
            LastFire = Time.time;
        }
    }
}
