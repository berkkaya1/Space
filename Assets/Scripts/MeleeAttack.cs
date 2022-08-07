using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] int enemyDamage;
    [SerializeField] EnemyStateManager enemy;
    [SerializeField] PlayerHealth player;
    int playerhp;

    private void Start()
    {
        playerhp = player.GetPlayerHealth();
        enemyDamage = enemy.enemyType.enemyDamage;
    }
    public void OnTriggerEnter(Collider other)
    {

        playerhp -= enemy.GetEnemyDamage();
        player.healthSystem.Damage(enemy.GetEnemyDamage());
        player.SetPlayerHealth(playerhp);

        if (player.GetPlayerHealth() <= 0)
        {
            player.SetIsPlayerDie(true);
            Debug.Log("Player is death");

        }

    }

}
