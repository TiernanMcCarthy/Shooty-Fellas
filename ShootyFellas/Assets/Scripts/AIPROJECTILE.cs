using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPROJECTILE : MonoBehaviour
{

    public float Damage;

    public float Speed;

    public Character Player;

    public Rigidbody2D rig2d;

    public float SpawnTime;

    public float LiveTime;

    public EnemySpawner Spawner;

    public void Init(Character player,float speed,float damage)
    {
        //Player = player;

        // Speed = speed;

        // Damage = damage;

        //rig2d = gameObject.AddComponent<Rigidbody2D>();


    }

    private void Start()
    {
        //StartCoroutine(DeathCountdown());
        Spawner = FindObjectOfType<EnemySpawner>();
    }

    private void FixedUpdate()
    {
        if (Time.time - SpawnTime >= LiveTime)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            //Spawner.LastPowerUpSpawn = Time.time;
            Player.Damage(Damage);
            Destroy(gameObject);
        }
    }

    public IEnumerator DeathCountdown()
    {
        Debug.Log("NO??");
        if(Time.time-SpawnTime>=LiveTime)
        {
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(2);
    }

}
