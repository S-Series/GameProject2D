using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private Dictionary<Status, Action> statusActions;
    public enum Status { Idle, Apch, KeepDist, Retreat }
    private Status status = Status.Idle;

    public int actionTick { get; private set; }
    public int rotateTick { get; private set; }

    public int[] retreatTick = { 0, 7 * 15 };
    public float moveSpeed = 3f;
    public float playerDistance = 0f;
    public float[] targetDistance = { 5f, 6f };

    private bool isIdle = false;
    private Transform player;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        if (player == null) player = GameManager.s_Player;

        EnemyManager.Enemies.Add(this);
        rb = GetComponent<Rigidbody2D>();

        statusActions = new Dictionary<Status, Action>
        {
            {Status.Idle, IdleAction},
            {Status.Apch, ApproachAction},
            {Status.Retreat, RetreatAction},
            {Status.KeepDist, KeepDistAction}
        };
    }

    public void TickAction()
    {
        UpdateStatus();
        RunTickAction();

        retreatTick[0]--;
        actionTick--;
        if (actionTick < 0) { AttackAction(); }
    }

    private void RunTickAction()
    {
        statusActions.TryGetValue(status, out Action action);
        action?.Invoke();   
    }
    private void UpdateStatus()
    {
        playerDistance = Vector2.Distance(rb.position, player.position);

        if (isIdle) { status = Status.Idle; }
        else if (playerDistance < targetDistance[0]) { status = Status.Retreat; }
        else if (playerDistance > targetDistance[1]) { status = Status.Apch; }
        else { status = Status.KeepDist; }
    }
    
    public virtual void AttackAction()
    {
        Debug.Log("Attack!");
    }
    public virtual void IdleAction()
    {
        Debug.Log("Idle..");
    }
    public virtual void ApproachAction()
    {
        //$ Walk to Approach to player by 100% speed
    }
    public virtual void RetreatAction()
    {
        if (retreatTick[0] < 0)
        {
            //$ Backdash Action
        }
        else
        {
            //$ Walk Faraway from player by 25% speed
        }
    }
    public virtual void KeepDistAction()
    {
        
    }

    /*public virtual void MoveAction()
    {
        Vector2 currentPos = rb.position;
        Vector2 playerPos = (Vector2)player.position;
        float currentDistance = Vector2.Distance(currentPos, playerPos);

        Vector2 desiredDirection = Vector2.zero;
        float finalSpeed = moveSpeed;

        if (currentDistance < targetDistance - tolerance)
        {
            desiredDirection = (currentPos - playerPos).normalized;
            finalSpeed = moveSpeed;
            rampCounter = -1;
        }
        else if (currentDistance > targetDistance + tolerance)
        {
            desiredDirection = (playerPos - currentPos).normalized;
            finalSpeed = moveSpeed;
            rampCounter = -1;
        }
        else
        {
            float normalOrbitSpeed = moveSpeed / 2f;
            Vector2 toPlayer = (currentPos - playerPos).normalized;
            Vector2 computedOrbitDirection = isLeft 
                ? new Vector2(-toPlayer.y, toPlayer.x)   
                : new Vector2(toPlayer.y, -toPlayer.x);    

            if (isLeft != previousIsLeft && rampCounter == -1)
            {
                rampCounter = 0;
                oldOrbitDirection = previousIsLeft 
                    ? new Vector2(-toPlayer.y, toPlayer.x)
                    : new Vector2(toPlayer.y, -toPlayer.x);
                newOrbitDirection = computedOrbitDirection;
            }

            int totalSteps = rotationPauseTick * 2;
            if (rampCounter != -1)
            {
                float t = rampCounter / (float)totalSteps;
                desiredDirection = Vector2.Lerp(oldOrbitDirection, newOrbitDirection, t);
                finalSpeed = normalOrbitSpeed;
                rampCounter++;
                if (rampCounter > totalSteps)
                {
                    rampCounter = -1;
                    previousIsLeft = isLeft;
                }
            }
            else
            {
                desiredDirection = computedOrbitDirection;
                finalSpeed = normalOrbitSpeed;
            }
        }

        Vector2 targetVec = desiredDirection * baseVec.magnitude;
        rb.linearVelocity = targetVec * finalSpeed;
    }
    public virtual void AttackAction()
    {
        print($"{this.name} Attack");
        actionTick = Random.Range(Ticks[0], Ticks[1] + 1);
    }

    private void RotateAction()
    {
        rotateTick = Ticks[2];
        isLeft = Random.Range(0, 1 + 1) == 0;
    }*/
}
