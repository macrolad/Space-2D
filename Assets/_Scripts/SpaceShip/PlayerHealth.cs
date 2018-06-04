using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : _BaseHealth, IAssignValues
{
    public void AssignValues(SpaceShipScriptable myShip)
    {
        MaxHealth = myShip.Cockpit.Health;
    }
}
