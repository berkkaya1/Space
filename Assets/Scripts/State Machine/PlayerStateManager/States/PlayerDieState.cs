using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.SetTrigger("isPlayerDie");
        player.hpBar.SetActive(false);
    }
    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
    public override void UpdateState(PlayerStateManager player)
    {
        return;
    }
}
