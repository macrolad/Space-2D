using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float Force;
    public float RotForce;

    Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        ForceAtSpawn();
    }

    public void ForceAtSpawn()
    {
        RB.AddForce(new Vector2(Random.Range(-Force, Force), Random.Range(-Force, Force)), ForceMode2D.Impulse);
        RB.AddTorque(Random.Range(-RotForce, RotForce), ForceMode2D.Impulse);
    }
}
