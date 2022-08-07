using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enemy Patrolling State");
        enemy.animator.SetTrigger("isPatroling");
    }

    public override void OnPatroling(EnemyStateManager enemy)
    {
        if (!enemy.walkPointSet)
        {
            SearchWalkPoint(enemy);
        }

        if (enemy.walkPointSet)
        {
            enemy.navMeshAgent.SetDestination(enemy.walkPoint);
            Vector3 distanceToWalkPoint = enemy.transform.position - enemy.walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                enemy.walkPointSet = false;
            }
        }
    }



    private void SearchWalkPoint(EnemyStateManager enemy)
    {

        float randomX = Random.Range(-enemy.walkPointRange, enemy.walkPointRange);

        enemy.walkPoint = new Vector3(enemy.transform.position.x + randomX, enemy.transform.position.y, enemy.transform.position.z);
        if (Physics.Raycast(enemy.walkPoint, -enemy.transform.up, 2f, enemy.whatIsGround))
        {
            enemy.walkPointSet = true;
        }

    }

    public override void ExitState(EnemyStateManager enemy)
    {
        enemy.animator.ResetTrigger("isPatroling");
    }


}
