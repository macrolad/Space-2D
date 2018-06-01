using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseHealth : MonoBehaviour
{
    public float MaxHealth;
    public float Health;

    [Space]
    public List<GameObject> DebrisList = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        SetHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void SetHealth(float max)
    {
        MaxHealth = max;
        Health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Death()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            SpawnDebris();
        }
    }

    public void SpawnDebris()
    {
        for (int i = 0; i < DebrisList.Count; i++)
        {
            DebrisList[i].SetActive(true);
            DebrisList[i].transform.position = transform.position;
        }
    }
}
