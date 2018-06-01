using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpObject : MonoBehaviour
{
    public Vector2 HalfExtends;

    private void Start()
    {
        HalfExtends = GameParameters.instance.MapHalfExtends;
    }

    private void Update()
    {
        CheckWarp();
    }

    public void CheckWarp()
    {
        if (transform.position.x > HalfExtends.x)
        {
            Warp(Vector2.left, HalfExtends.x);
        }
        if (transform.position.x < -HalfExtends.x)
        {
            Warp(Vector2.right, HalfExtends.x);
        }
        if (transform.position.y > HalfExtends.y)
        {
            Warp(Vector2.down, HalfExtends.y);
        }
        if (transform.position.y < -HalfExtends.y)
        {
            Warp(Vector2.up, HalfExtends.y);
        }
    }

    public void Warp(Vector3 axis, float warpDistance)
    {
        transform.position += axis * warpDistance * 2;
        if (_SetUpPlayer.Player == GetComponent<_SetUpPlayer>())
        {
            Camera.main.transform.position += axis * warpDistance * 2;
        }
    }
}
