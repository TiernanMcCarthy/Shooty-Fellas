using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrenade : MonoBehaviour
{
    public Hand handDirection;
    public GameObject defaultGrenade;

    [SerializeField]
    float lastGrenadeTime = 0;
    [SerializeField]
    float grenadeWaitTime;

    public bool canThrow;
    void Start()
    {
        PrepareNextGrenade();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.G))
        //{
        //    LaunchGrenade(defaultGrenade);
        //}
        if(Time.time - lastGrenadeTime > grenadeWaitTime)
        {
            canThrow = true;
        }
        if(canThrow)
        {
            LaunchGrenade(defaultGrenade);
        }
    }

    void LaunchGrenade(GameObject grenadeToSpawn)
    {
        grenadeToSpawn.GetComponent<GrenadeMovement>().launchDirection = handDirection.directionFacing;
        Instantiate(grenadeToSpawn, transform.position, transform.rotation);
        canThrow = false;
        lastGrenadeTime = Time.time;
        PrepareNextGrenade();
    }

    void PrepareNextGrenade()
    {
        grenadeWaitTime = Random.Range(10, 20);

    }
}
