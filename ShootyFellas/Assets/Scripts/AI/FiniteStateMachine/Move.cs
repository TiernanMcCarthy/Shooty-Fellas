using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{

    public override void Execute(StateObject s)
    {

        Enemy Temp = s.GetComponent<Enemy>();
        if(Temp.Move())
        {
            Temp.CurrentState = new Shoot();
        }

        
    }

}
