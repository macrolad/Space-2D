using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform TargetSprite;
    public Transform MySprite;

    [Header("Movement")]
    public float AccMovSpeed;
    public float MovSpeed;
    public float DragSpeed;
    [Space]
    [Header("Rotation")]
    public float AccRotSpeed;
    public float RotSpeed;
    public float StabilizeSpeed;
    [Space]
    [Header("Angles")]
    public float MovAngle;
    public float RotAngle;
    public LayerMask ObstacleLayermask;

    Rigidbody2D RB;
    Vector2 TargetPos;
    float AngleDir;

    // Use this for initialization
    void Start()
    {
        TargetSprite = _SetUpPlayer.Player.GetComponent<WarpSprite>().MyObject;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindObstacle();

        if (GetComponent<AIEnemy>().AIState == AIEnemy.AIStates.Chase)
        {
            GetDir(TargetSprite.position);
            Rotate();
            Move();
        }
        if (GetComponent<AIEnemy>().AIState == AIEnemy.AIStates.Avoid)
        {
            GetDir(-TargetSprite.position);
            Rotate();
            Move();
        }
    }

    public void GetDir(Vector2 target)
    {
        TargetPos = (Vector3)target - MySprite.position;
        AngleDir = Vector2.SignedAngle(transform.up, TargetPos);
    }

    public void Rotate()
    {
        RB.angularVelocity = Mathf.Lerp(RB.angularVelocity, Mathf.Sign(AngleDir) * RotSpeed, Time.deltaTime * AccRotSpeed);
    }
    
    public void Move()
    {
        if (AngleDir <= MovAngle || AngleDir >= -MovAngle)
        {
            RB.velocity = Vector2.Lerp(RB.velocity, transform.up * MovSpeed, Time.deltaTime * AccMovSpeed);
        }
    }

    public void FindObstacle()
    {
        RaycastHit hit;
        if (Physics.Raycast(MySprite.position, MySprite.up, out hit, 5,ObstacleLayermask))
        {
            GetComponent<AIEnemy>().Obstacle = true;
            TargetSprite = hit.transform;
        }
        GetComponent<AIEnemy>().Obstacle = false;
        TargetSprite = _SetUpPlayer.Player.GetComponent<WarpSprite>().MyObject;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(MySprite.position, MySprite.up * 5);
    }
}
