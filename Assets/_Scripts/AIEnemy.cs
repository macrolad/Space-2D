using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public enum AIStates
    {
        Chase,
        Attack,
        Avoid
    }
    public AIStates AIState;

    [Space]
    public bool Obstacle;
    public bool TargetInRange;

    [Space]
    public LayerMask ObstacleLayermask;

    private void Update()
    {
        switch (AIState)
        {
            case AIStates.Avoid:

                if (!Obstacle)
                {
                    SetChase();
                }

                break;
            case AIStates.Chase:

                if (Obstacle)
                {
                    SetAvoid();
                }
                if (TargetInRange)
                {
                    SetAttack();
                }

                break;
            case AIStates.Attack:

                if (Obstacle)
                {
                    SetAvoid();
                }
                if (!TargetInRange)
                {
                    SetChase();
                }

                break;
        }
    }

    public void SetChase() { AIState = AIStates.Chase; }
    public void SetAttack() { AIState = AIStates.Attack; }
    public void SetAvoid() { AIState = AIStates.Avoid; }
    
}
