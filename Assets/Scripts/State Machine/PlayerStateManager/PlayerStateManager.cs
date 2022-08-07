using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public float attackRange = 10f;
    public int playerDamage;
    public LayerMask enemyLayer;
    public Vector2 joystickInput;
    public CharacterController characterController;
    public Joystick joystick;
    float moveSpeed = 7;
    public Animator animator;
    public GameObject hpBar;
    //! 

    //Holds a ref to the active state in state machine
    public PlayerBaseState currentState;
    public PlayerAttackState playerAttackState = new PlayerAttackState();
    public PlayerDieState playerDieState = new PlayerDieState();
    public PlayerMoveState playerMoveState = new PlayerMoveState();
    public PlayerIdleState playerIdleState = new PlayerIdleState();

    void Start()
    {

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        currentState = playerIdleState;
        SwitchState(currentState);
        
    }

    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        StopAllCoroutines();
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
        StartCoroutine(currentState.Coroutine(this));
    }

    public int GetPlayerDamage()
    {
        return playerDamage;
    }

    void OnDrawGizmosSelected()
    {
        //attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
