using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public Base_Upgrade powerup;

    public Character Target;

    //public CharacterController CC;

    public Rigidbody2D rig2d;

    public float Speed;

    public float MaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        Target = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        //CC.Move((Target.transform.position - transform.position).normalized * Speed);
        rig2d.AddForce((Target.transform.position - transform.position).normalized * Speed, ForceMode2D.Impulse);
         
        if(rig2d.velocity.magnitude>MaxSpeed)
        {
            rig2d.velocity = MaxSpeed * (rig2d.velocity.normalized);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NO??");
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
    }
}
