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

    public AIPROJECTILE Prefab;
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

        return false;
    }

    public void Fire()
    {
        if(Time.time-LastFire>=FireTime)
        {
            //Debug.Log("Bang Bang");
            AMMO--;
            AIPROJECTILE temp=Instantiate(Prefab, transform.position+ (Target.transform.position - transform.position).normalized*0.5f, Quaternion.Euler(0,0,0)).GetComponent<AIPROJECTILE>();
            temp.rig2d = temp.GetComponent<Rigidbody2D>();
            temp.rig2d.AddForce((Target.transform.position - transform.position).normalized * Speed,ForceMode2D.Impulse);
            temp.Player = Target;
            temp.SpawnTime = Time.time;
            temp.Init(Target, 0, 0);
            //temp.rig2d.AddForce(transform.right * Prefab.Speed,ForceMode2D.Impulse);
            
            LastFire = Time.time;
        }
    }
}
