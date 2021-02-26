using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : State
{
    public override void Execute(StateObject s)
    {
        Enemy Temp = s.GetComponent<Enemy>();
        if (Vector3.Distance(Temp.transform.position, Temp.Target.transform.position) < Temp.Range)
        {
            if (Temp.AMMO > 0)
            {

                Temp.Fire();
            }
            else
            {
                Temp.Reloading = true;
                Temp.CurrentState = new Flee();
            }
        }
        else
        {
            Temp.CurrentState = new Seek();
        }
    }


}
