using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;


public class EnemyHealth : MonoBehaviour, IGetHealthSystem
{
    [SerializeField] EnemyType enemyType;
    [SerializeField] int enemyHealth;
    public HealthSystem healthSystem;
    //!
    PlayerStateManager playerDamage;
    EnemyStateManager enemy;
    public bool isEnemyDeath;
    //!

    private void Awake()
    {
        healthSystem = new HealthSystem(enemyType.enemyHealth);
    }




    void Start()
    {
        isEnemyDeath = false;
        enemyHealth = enemyType.enemyHealth;
        //!
        playerDamage = FindObjectOfType<PlayerStateManager>();
        enemy = GetComponent<EnemyStateManager>();


        //!

    }

    public int GetEnemyHealth()
    {
        return enemyHealth;
    }
    public void SetEnemyHealth(int hp)
    {
        enemyHealth = hp;
    }
    //!
    public bool IsEnemyDie()
    {
        return isEnemyDeath;
    }

    public void SetEnemyDie(bool isEnemyDeath)
    {
        this.isEnemyDeath = isEnemyDeath;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
