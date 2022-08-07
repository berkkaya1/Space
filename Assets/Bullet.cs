using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemyStateManager enemyStateManager;
    public PlayerStateManager playerStateManager;
    int playerhp, enemyhp;



    private void Start()
    {
        //playerhp = playerStateManager.playerHealth.GetPlayerHealth();
        enemyhp = enemyStateManager.enemyType.enemyHealth;
        playerhp = playerStateManager.playerHealth.GetPlayerHealth();

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.layer == 8)
        {
            enemyhp -= playerStateManager.GetPlayerDamage();
            enemyStateManager.enemyHealth.SetEnemyHealth(enemyhp);
            enemyStateManager.enemyHealth.healthSystem.Damage(playerStateManager.GetPlayerDamage());
            Destroy(gameObject);


            if (enemyStateManager.enemyHealth.GetEnemyHealth() <= 0)
            {

                enemyStateManager.enemyHealth.SetEnemyDie(true);
            }

        }

        if (other.gameObject.layer == 6)
        {
            playerhp -= enemyStateManager.GetEnemyDamage();
            playerStateManager.playerHealth.SetPlayerHealth(playerhp);
            playerStateManager.playerHealth.healthSystem.Damage(enemyStateManager.GetEnemyDamage());
            Destroy(gameObject);

            if (playerStateManager.playerHealth.GetPlayerHealth() <= 0)
            {
                playerStateManager.playerHealth.SetIsPlayerDie(true);
            }

        }
    }

}
