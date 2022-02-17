using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMoleMachine : GameMachine
{
    public List<Mole> moleList;

    public override void StartMachine()
    {
        base.StartMachine();

        foreach (Mole mole in moleList)
        {
            mole.isActive = true;
            mole.PopUp();
        }
    }

    public override void StopMachine()
    {
        base.StopMachine();

        foreach (Mole mole in moleList)
        {
            mole.Deactivate();
            mole.isActive = false;
            mole.FallDown();
        }
    }

}
