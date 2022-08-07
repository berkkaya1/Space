using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using CodeMonkey.HealthSystemCM;

public class EnemyStateManager : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    [SerializeField] public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public int enemyDamage;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator animator;
    public EnemyType enemyType;
    //!
    PlayerHealth playerHealth;
    public GameObject weapon;
    public Collider enemycollider;
    public EnemyHealth enemyHealth;
    //! &/&&
    public GameObject hpBar;


    public EnemyStateManager enemyStateManager;
    //!
    public EnemyBaseState currentState;
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyPatrolingState enemyPatrolingState = new EnemyPatrolingState();
    public EnemyChaseState enemyChaseState = new EnemyChaseState();
    public EnemyDieState enemyDieState = new EnemyDieState();

    void Start()
    {
        currentState = enemyPatrolingState;
        enemyPatrolingState.EnterState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //!
        enemyHealth = GetComponent<EnemyHealth>();
        enemyStateManager = GetComponent<EnemyStateManager>();
        enemyDamage = enemyType.enemyDamage;
        Debug.Log(enemyDamage);

        //particle vs de tanımlamak lazım sonrasında attackta vs.

    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(EnemyBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public int GetEnemyDamage()
    {
        return enemyDamage;
    }

    //Chaseplayer-Attack Player range gizmo
    void OnDrawGizmosSelected()
    {
        //sight range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        //attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        //walk range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }
}
