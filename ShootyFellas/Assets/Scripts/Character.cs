using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterController Player;
    
    [Header("Health")]
    public float Health = 100;
    public float MaxHealth = 100;
    public float DamageMultiplier = 1f;

    [Header("Movement")]
    public float Speed = 5.0f;
    public float SpeedMultiplier = 1.0f;
    public float SpeedMultiplierDefault = 1.0f;
    public float MinimumDistancePerFrame = 0.4f;
    
   

    [Header("Guns")]
    public FakeGun CurrentWeapon;
    public float ReloadMultiplier = 1.0f;
    public float ReloadMultiplierDefault = 1.0f;
    public float GunForceMultiplier = 1.0f;
    public float GunForceMultiplierDefault = 1.0f;
    public float AmmoMultiplier = 1.0f;
    public int currentGun = 0;
    public int currentGrenade = 0;

    public bool IsMoving = false;
    float LastMoveTime;



    private void Start()
    {
        Player = GetComponent<CharacterController>();

        Player.enabled = true;
    }

  
    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCoroutine(CheckDistanceTravelled());
    }


    void Movement()
    {

        if(Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical")!=0)
        {
            //IsMoving = true;
            
            Player.Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Speed*Time.deltaTime);

        }
        else
        {
            //IsMoving = false;
        }

        //Player.Move(new Vector3(1, 0, 0)*Time.deltaTime);

    }


    IEnumerator CheckDistanceTravelled()
    {
        Vector3 Pos = transform.position;
        LastMoveTime = Time.time;

        yield return new WaitForSeconds(2);
        IsMoving = Vector3.Distance(transform.position, Pos) > MinimumDistancePerFrame;

        //if ()
        //{
           // IsMoving = true;
       // }

    }

    public void Damage(float Amount)
    {
        Health += Amount*DamageMultiplier;

        if(Health>MaxHealth)
        {
            Health = MaxHealth;
        }

    }
}
