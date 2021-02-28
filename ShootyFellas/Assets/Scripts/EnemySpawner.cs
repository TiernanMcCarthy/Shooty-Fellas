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

    public GameObject pistol;
    public GameObject shotgun;
    public GameObject FAMAS;
    public GameObject M4A1;
    public GameObject minigun;

    public GameObject grenade1;
    public GameObject grenade2;
    public GameObject grenade3;

    [Header("SpawnLocations")]
    public List<Transform> SpawnLocations;
    public Enemy Prefab;
    public Powerup Powerupprefab;

    private float LastSpawnTime = 0;

    public float LastPowerUpSpawn = 0;
    // Start is called before the first frame update

    [Header("Power Up Chances")]
    public float WeaponChance = 0.5f;
    public float InvincibilityChance = 0.1f;
    public float GrenadeUpgrade = 0.1f;
    public float ReloadUpgrade = 0.3f;
    public float Total = 1;

    private void Start()
    {
        Debug.Log("lol");
        LastSpawnTime = Time.time;
        //InvincibilityChance = 0;
        //ModifyVariables(ref WeaponChance, ref GrenadeUpgrade, ref ReloadUpgrade, 0.1f);
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
                    Debug.Log("invicible");
                    temp.gameObject.AddComponent<InvincibilityPowerup>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<InvincibilityPowerup>();
                    //ModifyVariables(ref WeaponChance, ref GrenadeUpgrade, ref ReloadUpgrade,0);
                    break;
                case 1:
                    Debug.Log("Reload");
                    temp.gameObject.AddComponent<ReloadShorten>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<ReloadShorten>();
                    ModifyVariables(ref WeaponChance, ref InvincibilityChance, ref GrenadeUpgrade, ReloadUpgrade * 0.33f);
                    ReloadUpgrade = ReloadUpgrade * 0.77f;
                    break;
                case 2:
                    Debug.Log("gun upgrade");
                    temp.gameObject.AddComponent<GunUpgrade>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<GunUpgrade>();
                    temp.GetComponent<GunUpgrade>().gunList.Add(pistol);
                    temp.GetComponent<GunUpgrade>().gunList.Add(shotgun);
                    temp.GetComponent<GunUpgrade>().gunList.Add(FAMAS);
                    temp.GetComponent<GunUpgrade>().gunList.Add(M4A1);
                    temp.GetComponent<GunUpgrade>().gunList.Add(minigun);
                    break;


                case 3:
                    Debug.Log("Grenade upgrade");
                    temp.gameObject.AddComponent<GrenadeUpgrade>();
                    temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<GrenadeUpgrade>();
                    temp.GetComponent<GrenadeUpgrade>().grenadeList.Add(grenade1);
                    temp.GetComponent<GrenadeUpgrade>().grenadeList.Add(grenade2);
                    temp.GetComponent<GrenadeUpgrade>().grenadeList.Add(grenade3);

                    break;

            }


            temp.transform.position = Areas[Random.Range(0, 4)];
            temp.Target = FindObjectOfType<Character>();
            LastPowerUpSpawn = Time.time;
        }
    }

    void ModifyVariables(ref float Var1,ref float Var2,ref float Var3,float Distribute)
    {
        Var1 += Distribute / 3;
        Var2 += Distribute / 3;
        Var3 += Distribute / 3;
        //Vector4 temp =new Vector4(WeaponChance, InvincibilityChance, GrenadeUpgrade, ReloadUpgrade);
        //WeaponChance = temp[0];
       // InvincibilityChance = temp[1];
       // GrenadeUpgrade = temp[2];
       // ReloadUpgrade = temp[3];
        Total = WeaponChance + InvincibilityChance + GrenadeUpgrade + ReloadUpgrade;
    }

    

}
