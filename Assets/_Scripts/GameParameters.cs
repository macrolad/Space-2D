using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    public static GameParameters instance;

    [Header("Map")]
    public Vector2 MapHalfExtends;
    public Vector2[] Corners;

    private void Awake()
    {
        instance = this;
        SetCorners();
    }

    public void SetCorners()
    {
        Corners = new Vector2[9];
        int corner = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Corners[corner] = new Vector2(MapHalfExtends.x * x, MapHalfExtends.y * y);
                corner++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < Corners.Length; i++)
        {
            Gizmos.DrawWireSphere(Corners[i], 0.5f);
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector2.zero, MapHalfExtends * 2);
    }
}
