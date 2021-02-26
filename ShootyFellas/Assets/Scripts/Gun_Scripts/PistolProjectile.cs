using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : BaseProjectile
{
    
    public override void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("lmao hi");
            this.rb.velocity = Vector2.zero;
            this.gameObject.SetActive(false);
        }

    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        Debug.Log("bullet start haha");
        this.rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }


}
