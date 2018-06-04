using UnityEngine;

[CreateAssetMenu(fileName = "New Cockpit", menuName = "Space2D/Cockpit", order = 101)]
public class CockpitScriptable : PartScriptable
{
    public float Health;

    [Space]
    public float SpeedMod = 1;
}
