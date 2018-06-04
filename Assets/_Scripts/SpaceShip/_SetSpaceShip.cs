using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SetSpaceShip : MonoBehaviour
{
    public SpaceShipScriptable MyShip;

    private void Start()
    {
        AssignValues();
    }

    public void AssignValues()
    {
        GetComponent<PlayerHealth>().AssignValues(MyShip);
        GetComponent<PlayerMovement>().AssignValues(MyShip);
        GetComponent<PlayerShoot>().AssignValues(MyShip);
    }
}
