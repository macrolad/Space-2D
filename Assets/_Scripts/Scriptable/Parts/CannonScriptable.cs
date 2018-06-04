using UnityEngine;

[CreateAssetMenu(fileName = "New Cannon", menuName = "Space2D/Cannon", order = 102)]
public class CannonScriptable : PartScriptable
{
    public float Damage;
    public float Cooldown;
    public Projectile ProjPrefab;
}
