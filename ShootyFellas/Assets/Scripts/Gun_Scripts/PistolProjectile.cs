using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : BaseProjectile
{
    public int Bounces = 1;

    public float Life = 5.0f;
    private float SpawnTime = 0;
    public override void Start()
    {
        SpawnTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(Time.time-SpawnTime>Life)
        {
            this.rb.velocity = Vector2.zero;

            this.gameObject.SetActive(false);
            Bounces = 1;
        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I HIT A FUCKING WALL");
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            Debug.Log("lmao hi");
            if (collision.gameObject.tag == "Enemy")
            {
                this.rb.velocity = Vector2.zero;

                this.gameObject.SetActive(false);
            }
            if (collision.gameObject.tag == "Wall")
            {
                if(Bounces==0)
                {
                    this.rb.velocity = Vector2.zero;

                    this.gameObject.SetActive(false);
                }
                else
                {
                    //RaycastHit hit;
                    //  Physics.Raycast(transform.position, transform.forward, out hit);

                    //Debug.Log("Point of contact: " + hit.point);
                    //rb.velocity = hit.normal * rb.velocity;
                    //rb.velocity = rb.velocity * -1;
                    
                    //rb.velocity = collision.GetContact(0).normal*speed;
                    Bounces -= 1;
                }
            }
        }

    }
   // OnTriggerEnter(Collider other)
   // {

        //RaycastHit hit;
       // if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
        //    Debug.Log("Point of contact: " + hit.point);
      //  }
   // }
    public override void OnSpawn()
    {
        base.OnSpawn();
        SpawnTime = Time.time;
        Debug.Log("bullet start haha");
        Bounces = 1;
        this.rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }


}
