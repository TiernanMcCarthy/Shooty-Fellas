using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    bool ReloadingOnce = true;
    float ReloadingTime = 0;
    public override void Execute(StateObject s)
    {

        Enemy Temp = s.GetComponent<Enemy>();

        
       // Debug.Log("GAMING");
        if(Temp.Move()==true)
        {
            if (Vector3.Distance(Temp.transform.position, Temp.Target.transform.position) < Temp.Range)
            {
                Temp.CurrentState = new Shoot();
            }
            else
            {
                if(Temp.Reloading)
                {
                    Temp.Reloading = false;
                    ReloadingOnce = true;
                    ReloadingTime = Time.time;
                }
                if (ReloadingOnce && Time.time - Temp.ReloadingTime > ReloadingTime)
                {
                    Temp.CurrentState = new Seek();
                }
            }

        }

        
    }

}
