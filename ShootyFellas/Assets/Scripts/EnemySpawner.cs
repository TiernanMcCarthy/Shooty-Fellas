using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Parameters")]
    public int MaxMatt = 10;
    public int MaxPowerup = 1;
    public float SpawnInterval = 5.0f;
    public bool CanSpawnEnemies = true;
    public int NumberOfMatts = 0;

    [Header("SpawnLocations")]
    public List<Transform> SpawnLocations;
    public Enemy Prefab;

    private float LastSpawnTime = 0;
    // Start is called before the first frame update

    private void Start()
    {
        LastSpawnTime = Time.time;
    }
    private void FixedUpdate()
    {
        NumberOfMatts = FindObjectsOfType<Enemy>().Length;
        if(NumberOfMatts<MaxMatt && Time.time-LastSpawnTime>SpawnInterval)
        {
            LastSpawnTime = Time.time;
            GameObject temp=Instantiate(Prefab).gameObject;

            temp.transform.position = SpawnLocations[Random.Range(0, 10)].position;
        }
    }

}
