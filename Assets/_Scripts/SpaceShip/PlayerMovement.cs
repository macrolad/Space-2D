using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float AccMovSpeed;
    public float MovSpeed;
    public float DragSpeed;
    [Space]
    [Header("Rotation")]
    public float AccRotSpeed;
    public float RotSpeed;
    public float StabilizeSpeed;

    Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        Stabilize();
    }

    //public void AssignParameters(SpaceShipScriptable Ship)
    //{
    //    AccMovSpeed = Ship.AccMovSpeed;
    //    MovSpeed = Ship.MovSpeed;
    //    DragSpeed = Ship.DragSpeed;

    //    AccRotSpeed = Ship.AccRotSpeed;
    //    RotSpeed = Ship.RotSpeed;
    //    StabilizeSpeed = Ship.StabilizeSpeed;

    //}

    public void Move()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            RB.velocity = Vector2.Lerp(RB.velocity, Input.GetAxis("Vertical") * transform.up * MovSpeed, Time.deltaTime * AccMovSpeed);
        }
    }
    public void Rotate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            RB.angularVelocity = Mathf.Lerp(RB.angularVelocity, -Input.GetAxis("Horizontal") * RotSpeed, Time.deltaTime * AccRotSpeed);
        }
    }
    public void Stabilize()
    {
        if (Input.GetAxis("Vertical") == 0)
        {
            RB.velocity = Vector2.Lerp(RB.velocity, Vector2.zero, Time.deltaTime * DragSpeed);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            RB.angularVelocity = Mathf.Lerp(RB.angularVelocity, 0, StabilizeSpeed * Time.deltaTime);
        }
    }
}
