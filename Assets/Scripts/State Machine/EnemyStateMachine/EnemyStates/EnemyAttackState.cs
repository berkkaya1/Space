using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy Attack State");
        enemy.StartCoroutine(AttackPlayer(enemy));
        enemy.animator.SetTrigger("isAttack");


    }

    IEnumerator AttackPlayer(EnemyStateManager enemy)
    {
        while (true)
        {
            enemy.navMeshAgent.SetDestination(enemy.transform.position);
            enemy.transform.LookAt(enemy.player);
            yield return new WaitForSeconds(1f);
            //enemy.playerHealth.takeDamage(enemy.enemyDamage);

        }

    }

    public override void ExitState(EnemyStateManager enemy)
    {
        enemy.animator.ResetTrigger("isAttack");
        enemy.StopAllCoroutines();
    }


}
