using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : State
{

    public override void Execute(StateObject s)
    {
        Enemy Temp = s.GetComponent<Enemy>();
        Vector3 ugh = Temp.transform.position;
        
        while(Vector3.Distance(ugh,Temp.Target.transform.position)<9.0f)
        {
            ugh=new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        }

        Temp.MoveToLocation = ugh;
        Temp.AMMO = Temp.MaxAMMO;
        Temp.CurrentState = new Move();
    }
}
