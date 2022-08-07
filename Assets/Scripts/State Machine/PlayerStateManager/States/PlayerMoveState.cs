using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        //Debug.Log("Player Move State");
        player.animator.SetTrigger("isRunning");


    }
    public override void OnMove(PlayerStateManager player)
    {
        Vector3 currentDirection = new Vector3(player.joystickInput.x, 0, player.joystickInput.y) * 7 * Time.deltaTime;
        player.characterController.Move(currentDirection);
        player.transform.rotation = Quaternion.LookRotation(currentDirection);

    }
}
