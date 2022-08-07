using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy Chase State");
        enemy.animator.SetTrigger("isChasing");

    }

    public override void OnChasePlayer(EnemyStateManager enemy)
    {

        enemy.navMeshAgent.SetDestination(enemy.player.position);

    }

    public override void ExitState(EnemyStateManager enemy)
    {
        //enemy.animator.ResetTrigger("isChasing");
    }



}
