using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Upgrade : MonoBehaviour
{
    public EnemySpawner Spawner;
    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTouchPlayer()
    {

    }
}
