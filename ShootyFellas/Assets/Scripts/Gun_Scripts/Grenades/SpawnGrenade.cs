using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrenade : MonoBehaviour
{
    public Hand handDirection;
    public GameObject defaultGrenade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            LaunchGrenade(defaultGrenade);
        }
    }

    void LaunchGrenade(GameObject grenadeToSpawn)
    {
        grenadeToSpawn.GetComponent<GrenadeMovement>().launchDirection = handDirection.directionFacing;
        Instantiate(grenadeToSpawn, transform.position, transform.rotation);
    }
}
