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
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.GetComponent<PistolProjectile>())
        {
            Owner.Target.Damage(Owner.Damage); //Heal  
            Owner.Target.NumberOfMattsKilled++;
            other.gameObject.GetComponent<BaseProjectile>().gameObject.SetActive(false);
            Destroy(Owner.gameObject);
        }
        else if (other.gameObject.tag == Owner.Target.tag)
        {
            Owner.Target.Damage(Owner.Damage);
            Owner.Target.NumberOfMattsKilled++;
            Destroy(Owner.gameObject);
            //Debug.Log("NOOAOSOFAOSAFOsfoa");
            //Owner.Target.Damage(Owner.Damage);
           // Destroy(gameObject);
        }
    }
}
