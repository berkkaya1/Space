using System;
using System.Collections;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        //Debug.Log("Player Attack State");
        player.animator.SetTrigger("isAttack");

    }
    public override void OnAttack(PlayerStateManager player)
    {
        if (InAttackRange == null) return;
        if (InAttackRange.Length == 0) return;
        TurnToEnemy(player);



    }
    private void TurnToEnemy(PlayerStateManager player)
    {
        Transform enemy = InAttackRange[0].transform;

        Vector3 targetRotation = (enemy.transform.position - player.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z) * Time.deltaTime);
        player.transform.rotation = lookRotation;
    }
    public override void ExitState(PlayerStateManager player)
    {

    }
}

