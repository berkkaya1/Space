using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        //Debug.Log("Player Idle State");
        player.animator.SetTrigger("isIdle");
    }
    public override void OnIdle(PlayerStateManager player)
    {
        return;
    }
}
