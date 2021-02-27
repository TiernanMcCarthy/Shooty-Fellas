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
    public float PowerupSpawnInterval = 20.0f;


    [Header("SpawnLocations")]
    public List<Transform> SpawnLocations;
    public Enemy Prefab;
    public Powerup Powerupprefab;

    private float LastSpawnTime = 0;

    public float LastPowerUpSpawn = 0;
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
        float NumberOfPowerups = FindObjectsOfType<Powerup>().Length ;
        if(Time.time-LastPowerUpSpawn>PowerupSpawnInterval && NumberOfPowerups<1)
        {
            List<Vector3> Areas = new List<Vector3>();
            Areas.Add(new Vector3(-Board.Width / 2, Board.Height / 2, 0)); //Top Left
            Areas.Add(new Vector3(-Board.Width / 2, -Board.Height / 2, 0)); //Bottom Left
            Areas.Add(new Vector3(Board.Width / 2, Board.Height / 2, 0)); //Top Right
            Areas.Add(new Vector3(Board.Width / 2, -Board.Height / 2, 0)); //Bottom Righjt
            Powerup temp=Instantiate(Powerupprefab);
            int random = Random.Range(0, 3);
            switch(random)
            {
                case 0: //Invincibility
                    temp.gameObject.AddComponent<InvincibilityPowerup>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<InvincibilityPowerup>();
                    break;
                case 1:
                    temp.gameObject.AddComponent<ReloadShorten>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<ReloadShorten>();
                    break;
                case 2:
                    temp.gameObject.AddComponent<InvincibilityPowerup>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<InvincibilityPowerup>();
                    break;

                    

            }


            temp.transform.position = Areas[Random.Range(0, 4)];
            temp.Target = FindObjectOfType<Character>();
            LastPowerUpSpawn = Time.time;
        }
    }

}
