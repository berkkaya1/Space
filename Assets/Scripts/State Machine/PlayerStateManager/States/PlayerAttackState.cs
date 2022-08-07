using System;
using System.Collections;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private RaycastHit hit;
    private Health newEnemyHealth;
    private EnemyStateManager newEnemyStateManager;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Player Attack State");
        player.animator.SetTrigger("isAttack");

    }
    public override void OnAttack(PlayerStateManager player)
    {
        if (InAttackRange == null) return;
        if (InAttackRange.Length == 0) return;
        TurnToEnemy(player);

    }
  
    public override IEnumerator Coroutine(PlayerStateManager player)
    {
        while (true)
        {
            yield return new WaitForSeconds(.3f);
            
            if (Physics.Raycast(player.transform.position + (Vector3.up * 2), player.transform.forward,  out hit ,player.attackRange, player.enemyLayer))
            {
                // get enemy features
                newEnemyHealth = hit.transform.GetComponent<Health>();
                newEnemyStateManager = hit.transform.GetComponent<EnemyStateManager>();

                // enemy feature null check
                if (newEnemyHealth == null || newEnemyStateManager  == null) continue;
                if (newEnemyStateManager.isDead) continue;
               
                // reduce enemy health
                newEnemyHealth.TakeDamage(player.playerDamage);

                // if enemy dies
                if (!newEnemyHealth.CheckDeath()) continue;
                newEnemyStateManager.SwitchState(newEnemyStateManager.enemyDieState);
                
            }
           
        }
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

