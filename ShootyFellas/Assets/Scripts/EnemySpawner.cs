using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Parameters")]
    public int MaxMatt = 10;
    public int MaxPowerup = 1;
    public float SpawnInterval = 5.0f;
    public float MattSpawnIncrease = 4.0f;
    public bool CanSpawnEnemies = true;
    public int NumberOfMatts = 0;
    public float PowerupSpawnInterval = 20.0f;

    public Character Gamer;

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
    public int WeaponChance = 4;
    char Weap = 'W';
    public int InvincibilityChance = 1;
    char Inv = 'I';
    public int GrenadeUpgrade = 2;
    char Gre = 'G';
    public int ReloadUpgrade = 3;
    char Rel = 'R';
    public float Total = 1;

    public List<char> Chances;


    private float PreviousMattIterate = 4;

    public TextMeshProUGUI Timer;
    
    float startTime;
    public float TimeToPlay = 300; //5 Minutes


    public float Score = 0;
    public int MattsKilled = 0;

    bool InPlay = true;
    void GenerateList()
    {
        /*Chances = new List<char>();
        for (int i = 0; i < Mathf.FloorToInt(10 * WeaponChance); i++)
        {
            Chances.Add(Weap);
        }

        for (int i = 0; i < Mathf.FloorToInt(10 * InvincibilityChance); i++)
        {
            Chances.Add(Inv);
        }

        for (int i = 0; i < Mathf.FloorToInt(10 * GrenadeUpgrade); i++)
        {
            Chances.Add(Gre);
        }

        for (int i = 0; i <= Mathf.FloorToInt(10 * ReloadUpgrade); i++)
        {
            Chances.Add(Rel);
        }*/

        Chances = new List<char>();

        for (int i = 0; i < WeaponChance; i++)
        {
            Chances.Add(Weap);
        }
        for (int i = 0; i < InvincibilityChance; i++)
        {
            Chances.Add(Inv);
        }
        for (int i = 0; i < GrenadeUpgrade; i++)
        {
            Chances.Add(Gre);
        }
        for (int i = 0; i < ReloadUpgrade; i++)
        {
            Chances.Add(Rel);
        }


    }

    private void Update()
    {
        float timey = Mathf.RoundToInt((Time.time - startTime) - TimeToPlay) * -1;
        Timer.text = "Time Remaining: " + timey ;
        if(timey<=0 && InPlay)
        {
            DontDestroyOnLoad(this.gameObject);
            Score = Gamer.Health;
            InPlay = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(3); //EndScreen;
        }    
    }
    private void Start()
    {
        Debug.Log("lol");
        LastSpawnTime = Time.time;
        startTime = Time.time;
        GenerateList();
        Gamer = FindObjectOfType<Character>();
  



        //InvincibilityChance = 0;
        //ModifyVariables(ref WeaponChance, ref GrenadeUpgrade, ref ReloadUpgrade, 0.1f);
    }
    private void FixedUpdate()
    {
        if (InPlay)
        {
            NumberOfMatts = FindObjectsOfType<Enemy>().Length;
            if (NumberOfMatts < MaxMatt && Time.time - LastSpawnTime > SpawnInterval)
            {
                LastSpawnTime = Time.time;
                GameObject temp = Instantiate(Prefab).gameObject;

                temp.transform.position = SpawnLocations[Random.Range(0, 10)].position;
            }
            float NumberOfPowerups = FindObjectsOfType<Powerup>().Length;
            if (Time.time - LastPowerUpSpawn > PowerupSpawnInterval && NumberOfPowerups < 1)
            {
                List<Vector3> Areas = new List<Vector3>();
                Areas.Add(new Vector3(-Board.Width / 2, Board.Height / 2, 0)); //Top Left
                Areas.Add(new Vector3(-Board.Width / 2, -Board.Height / 2, 0)); //Bottom Left
                Areas.Add(new Vector3(Board.Width / 2, Board.Height / 2, 0)); //Top Right
                Areas.Add(new Vector3(Board.Width / 2, -Board.Height / 2, 0)); //Bottom Righjt
                Powerup temp = Instantiate(Powerupprefab);
                char random = Chances[Random.Range(0, Chances.Count)];
                switch (random)
                {
                    case 'I': //Invincibility
                        Debug.Log("invicible");
                        temp.gameObject.AddComponent<InvincibilityPowerup>();
                        temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<InvincibilityPowerup>();
                        //ModifyVariables(ref WeaponChance, ref GrenadeUpgrade, ref ReloadUpgrade,0);
                        break;
                    case 'R':
                        Debug.Log("Reload");
                        temp.gameObject.AddComponent<ReloadShorten>();
                        temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<ReloadShorten>();

                        //ModifyVariables(ref WeaponChance, ref InvincibilityChance, ref GrenadeUpgrade, ReloadUpgrade * 0.33f);
                        //ReloadUpgrade = ReloadUpgrade * 0.77f;
                        //ReloadUpgrade -= 1;
                        GenerateList();
                        break;
                    case 'W':
                        Debug.Log("gun upgrade");
                        temp.gameObject.AddComponent<GunUpgrade>();
                        temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<GunUpgrade>();
                        temp.GetComponent<GunUpgrade>().gunList.Add(pistol);
                        temp.GetComponent<GunUpgrade>().gunList.Add(shotgun);
                        temp.GetComponent<GunUpgrade>().gunList.Add(FAMAS);
                        temp.GetComponent<GunUpgrade>().gunList.Add(M4A1);
                        temp.GetComponent<GunUpgrade>().gunList.Add(minigun);
                        // WeaponChance -=1;
                        GenerateList();
                        //ModifyVariables(ref InvincibilityChance, ref GrenadeUpgrade, ref ReloadUpgrade, WeaponChance - 0.05f);
                        //WeaponChance -= 0.05f;
                        break;


                    case 'G':
                        Debug.Log("Grenade upgrade");
                        temp.gameObject.AddComponent<GrenadeUpgrade>();
                        temp.GetComponent<UpgradeTouchPlayer>().thisUpgrade = temp.GetComponent<GrenadeUpgrade>();
                        temp.GetComponent<GrenadeUpgrade>().grenadeList.Add(grenade1);
                        temp.GetComponent<GrenadeUpgrade>().grenadeList.Add(grenade2);
                        temp.GetComponent<GrenadeUpgrade>().grenadeList.Add(grenade3);

                        //GrenadeUpgrade -= 1;
                        GenerateList();
                        break;

                }


                temp.transform.position = Areas[Random.Range(0, 4)];
                temp.Target = FindObjectOfType<Character>();
                LastPowerUpSpawn = Time.time;
            }

            if (Time.time - PreviousMattIterate > MattSpawnIncrease)
            {
                MaxMatt++;
                PreviousMattIterate = Time.time;
            }
        }
    }

    void ModifyVariables(ref float Var1,ref float Var2,ref float Var3,float Distribute)
    {
        Var1 += Distribute / 3;
        Var2 += Distribute / 3;
        Var3 += Distribute / 3;
        GenerateList();
        //Vector4 temp =new Vector4(WeaponChance, InvincibilityChance, GrenadeUpgrade, ReloadUpgrade);
        //WeaponChance = temp[0];
       // InvincibilityChance = temp[1];
       // GrenadeUpgrade = temp[2];
       // ReloadUpgrade = temp[3];
        Total = WeaponChance + InvincibilityChance + GrenadeUpgrade + ReloadUpgrade;
    }

    

}
