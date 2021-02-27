using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitTaker : MonoBehaviour
{

    public Enemy Owner; 
    // Start is called before the first frame update
    void Start()
    {
        Owner = transform.parent.gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PistolProjectile>())
        {
            Owner.Target.Damage(Owner.Damage); //Heal  
            other.gameObject.GetComponent<BaseProjectile>().gameObject.SetActive(false);
            Destroy(Owner.gameObject);
        }
        else if (other.gameObject == Owner.Target.gameObject)
        {
            Owner.Target.Damage(Owner.Damage);
            Destroy(Owner.gameObject);

        }
    }
}
