using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState, IKillable
{
    public void EnemyDie(EnemyStateManager enemy)
    {
        enemy.animator.SetTrigger("isDie");
        enemy.navMeshAgent.enabled = false;
        enemy.isDead = true;
        enemy.gameObject.layer = 11;
       // enemy.weapon.SetActive(false);
        enemy.enemycollider.enabled = false;
        //enemy.enemyStateManager.enabled = false;
        //enemy.hpBar.SetActive(false);
    }

    public override void EnterState(EnemyStateManager enemy)
    {
        EnemyDie(enemy);

    }

    //!
    public override void UpdateState(EnemyStateManager enemy)
    {
        return;
    }




}
