using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSprite : MonoBehaviour
{
    public Transform Target;
    public Transform MyObject;

    public Vector2 ClosestCorner;
    public Vector2 Offset;

    public Vector2 MapExtends;

    private void Start()
    {
        Target = _SetUpPlayer.Player.transform;
        MapExtends = GameParameters.instance.MapHalfExtends;
    }

    private void LateUpdate()
    {
        GetOffset();
        CompareDist();
    }

    //Get the object's closest corner and offset
    public void GetOffset()
    {
        float cornerDist = Mathf.Infinity;

        foreach (Vector3 corner in GameParameters.instance.Corners)
        {
            float distance = Vector3.Distance(transform.position, corner);

            if (distance < cornerDist)
            {
                ClosestCorner = corner;
                cornerDist = distance;
            }
        }

        Offset = transform.position - (Vector3)ClosestCorner;
    }

    //Compare real distance to player with distance using offset
    public void CompareDist()
    {
        Vector2 cornerDist = Vector2.Scale(ClosestCorner, Target.GetComponent<WarpSprite>().ClosestCorner);

        Vector2 offDist = transform.position;

        if (cornerDist.x < 0)
        {
            offDist = new Vector2(Target.GetComponent<WarpSprite>().ClosestCorner.x + Offset.x, offDist.y);
        }
        if (cornerDist.y < 0)
        {
            offDist = new Vector2(offDist.x, Target.GetComponent<WarpSprite>().ClosestCorner.y + Offset.y);
        }

        MyObject.position = offDist;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(transform.position, MyObject.position);

        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(ClosestCorner, 0.5f);
    }
}
