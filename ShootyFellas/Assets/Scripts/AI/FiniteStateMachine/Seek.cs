using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : State
{
    // Start is called before the first frame update

    //Move to Player, random offset from them, then fire for a bit, then hide and come back repeating
    public override void Execute(StateObject s)
    {
        Enemy Temp = s.GetComponent<Enemy>();
        if (Vector3.Distance(Temp.transform.position ,Temp.Target.transform.position)>Temp.EngageDistance-0.5f)
        {
            Temp.MoveToLocation = Temp.Target.transform.position + (Temp.transform.position - Temp.Target.transform.position).normalized * Temp.EngageDistance;
            Temp.CurrentState = new Move();
        }


        //throw new System.NotImplementedException();
    }
}
