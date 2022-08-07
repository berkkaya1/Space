using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class PlayerHealth : MonoBehaviour, IGetHealthSystem
{

    [SerializeField] int playerHealth;
    // [SerializeField] int enemyDamage;
    [SerializeField] EnemyStateManager enemy;
    public HealthSystem healthSystem;
    // public bool InAttackRange;

    public bool isPlayerDeath;

    private void Awake()
    {
        healthSystem = new HealthSystem(playerHealth);
    }

    void Start()
    {
        isPlayerDeath = false;
        // enemyDamage = enemy.enemyType.enemyDamage;
        //!

    }

    // private void OnParticleCollision(GameObject other)
    // {
    //     if (other.gameObject.tag == "Ranged Enemy")
    //     {
    //         playerHealth -= enemy.GetEnemyDamage();
    //         healthSystem.Damage(enemy.GetEnemyDamage());
    //         Debug.Log(playerHealth);

    //         if (playerHealth <= 0)
    //         {
    //             isPlayerDeath = true;
    //             Debug.Log("Player is death");

    //         }
    //     }

    // }

    // private void OnTriggerEnter(Collider other)
    // {

    //     if (other.gameObject.tag == "Sword")
    //     {
    //         InAttackRange = true;

    //         playerHealth -= enemy.GetEnemyDamage();
    //         healthSystem.Damage(enemy.GetEnemyDamage());
    //         Debug.Log(playerHealth);

    //         if (playerHealth <= 0)
    //         {
    //             isPlayerDeath = true;
    //             Debug.Log("Player is death");

    //         }
    //     }
    // }



    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag == "Melee Enemy")
    //     {
    //         InAttackRange = false;
    //     }
    // }

    //!
    public bool IsPlayerDie()
    {
        return isPlayerDeath;
    }

    public void SetIsPlayerDie(bool isPlayerDeath)
    {
        this.isPlayerDeath = isPlayerDeath;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetPlayerHealth(int hp)
    {
        playerHealth = hp;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
