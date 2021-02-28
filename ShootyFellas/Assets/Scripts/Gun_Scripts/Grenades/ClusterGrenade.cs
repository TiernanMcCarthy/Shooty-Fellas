using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterGrenade : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rb;
    public float startPos;
    public float radius;
    public GameObject explosionSprite;
    public float launchDirection;

    int layerMask = 1 << 9;
    bool hasExploded = false;
    void Start()
    {
        speed = Random.Range(0.5f, 5);
        launchDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        startPos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        var direction = (transform.right * launchDirection + Vector3.up);
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= startPos - 1 && !hasExploded)
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
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask, 0, 1);
        foreach (Collider2D hitCollider in hitColliders)
        {
            Destroy(hitCollider.transform.parent.gameObject);
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }

}
