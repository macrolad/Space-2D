using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceShip", menuName = "Space2D/SpaceShip", order = 0)]
public class SpaceShipScriptable : ScriptableObject
{
    public CockpitScriptable Cockpit;
    public CannonScriptable Cannons;
    public WingsScriptable Wings;
    public ThrustersScriptable Thrusters;
}
