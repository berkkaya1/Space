using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemy);
    public virtual void UpdateState(EnemyStateManager enemy)
    {
        enemy.playerInSightRange = Physics.CheckSphere(enemy.transform.position, enemy.sightRange, enemy.whatIsPlayer);
        enemy.playerInAttackRange = Physics.CheckSphere(enemy.transform.position, enemy.attackRange, enemy.whatIsPlayer);


        if (!enemy.playerInSightRange && !enemy.playerInAttackRange)
        {
            OnPatroling(enemy);
        }
        else if (enemy.playerInSightRange && !enemy.playerInAttackRange)
        {
            OnChasePlayer(enemy);
        }
        else if (enemy.playerInSightRange && enemy.playerInAttackRange)
        {
            OnAttack(enemy);
        }
        //!
        //if (enemy.enemyHealth.IsEnemyDie())
        //{
          //  OnDie(enemy);
        //}

        //  if (playerInSightRange && !playerInAttackRange) ChasePlayer();
    }
    public virtual void OnPatroling(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.enemyPatrolingState);
    }
    public virtual void OnChasePlayer(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.enemyChaseState);
    }
    public virtual void OnAttack(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.enemyAttackState);
    }
    //!
    public virtual void OnDie(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.enemyDieState);
    }
    public virtual void OnCollisionEnter(EnemyStateManager enemy) { }
    public virtual void ExitState(EnemyStateManager enemy) { }
}
