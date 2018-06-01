using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float Damage;
    public float Cooldown;
    public Projectile ProjPrefab;
    public Transform SpawnPos;

    bool CanAttack = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanAttack)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        CanAttack = false;
        SpawnProj();
        StartCoroutine("Reload");
    }

    public void SpawnProj()
    {
        Projectile myProj= Instantiate(ProjPrefab, SpawnPos.position, transform.rotation);
        myProj.Damage = Damage;
        myProj.MyPlayer = GetComponent<_BaseHealth>();
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(Cooldown);
        CanAttack = true;
    }
}
