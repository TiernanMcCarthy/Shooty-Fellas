using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMovement : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rb;
    public float startPos;
    public float radius;
    public GameObject explosionSprite;
    public float launchDirection;

    public bool isCluster = false;
    public GameObject cluster;
    int layerMask = 1 << 9;

    bool hasExploded = false;
    void Start()
    {
        startPos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        var direction = (transform.right * launchDirection + Vector3.up);
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= startPos-1 && !hasExploded)
        {
            Explode();
        }
    }

    void Explode()
    {
        hasExploded = true;
        explosionSprite.SetActive(true);
        this.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(rb);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius,layerMask,0,1);
        foreach (Collider2D hitCollider in hitColliders)
        {
            Destroy(hitCollider.transform.parent.gameObject);
        }
        if(isCluster)
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(cluster, transform.position, transform.rotation);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }


}
