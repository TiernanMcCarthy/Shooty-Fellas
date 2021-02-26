using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateObject
{
    public float EngageDistance = 5.0f;
    public float Speed = 5.0f;

    public float AMMO;

    public float FireTime = 1.0f;

    public Vector3 MoveToLocation;

    public State CurrentState;

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
        CC.Move((MoveToLocation-transform.position).normalized*Speed*Time.deltaTime);
        if(Vector3.Distance(transform.position,MoveToLocation)<0.5f)
        {
            return true;
        }

        return false;
    }
}
