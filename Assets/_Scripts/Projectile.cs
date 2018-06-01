using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public _BaseHealth MyPlayer;

    public Animator Anim;
    public bool isHit;

    bool CanHitSelf;

    private void Start()
    {
        Invoke("FireSelf", 0.3f);
    }

    private void Update()
    {
        if (!isHit)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<_BaseHealth>() != MyPlayer ||
            (collision.GetComponent<_BaseHealth>() == MyPlayer && CanHitSelf))
        {
            Impact(collision.GetComponent<_BaseHealth>());
        }
    }

    public void Impact(_BaseHealth hit)
    {
        isHit = true;
        Anim.SetTrigger("isHit");
        GetComponent<BoxCollider2D>().enabled = false;

        hit.TakeDamage(Damage);

        Destroy(gameObject, Anim.GetCurrentAnimatorStateInfo(0).length);
    }

    public void FireSelf()
    {
        CanHitSelf = true;
    }
}
