using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseProjectile : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    public Rigidbody2D rb;

    public CircleCollider2D coll;

    public float speed;

    public virtual void Start()
    {
        
    }

    public virtual void OnSpawn()
    {

    }


}