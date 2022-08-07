using System;
using UnityEngine;
using System.Collections;

public abstract class PlayerBaseState
{
    public Collider[] InAttackRange;

    public abstract void EnterState(PlayerStateManager player);
    public virtual void UpdateState(PlayerStateManager player)
    {
        InAttackRange = Physics.OverlapSphere(player.transform.position, player.attackRange, player.enemyLayer);
        //  // rotate the player.
        // OnRotate(player);

        // null check.
        if (player.joystickInput == null || player.joystick == null) return;

        // get the input from the joystick.
        player.joystickInput = new Vector2(player.joystick.Horizontal, player.joystick.Vertical);

        // if it is greater than a small value, move the player.
        if (player.joystickInput.sqrMagnitude >= .1f)
        { OnMove(player); }
        else if (InAttackRange.Length > 0)
        {
            OnAttack(player);
        }
        else { OnIdle(player); }

        //if (player.playerHealth.isPlayerDeath)
       // {
          //  OnDie(player);
        //}

    }

    public virtual IEnumerator Coroutine(PlayerStateManager  player)
    {
        yield return null;
    }

    public virtual void OnIdle(PlayerStateManager player)
    {
        player.SwitchState(player.playerIdleState);
    }
    public virtual void OnMove(PlayerStateManager player)
    {
        player.SwitchState(player.playerMoveState);
    }
    public virtual void OnAttack(PlayerStateManager player)
    {
        player.SwitchState(player.playerAttackState);
    }
    public virtual void OnDie(PlayerStateManager player)
    {
        player.SwitchState(player.playerDieState);
    }
    public virtual void OnCollisionEnter(PlayerStateManager player)
    {

    }
    public virtual void ExitState(PlayerStateManager player)
    {

    }

}
