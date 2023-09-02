using UnityEngine;

public class IdleState : AliveState
{
    private Animator _animator;
    
    public IdleState(CharacterStateMachine stateMachine, Animator animator, Enemy enemy) : base("Idle", stateMachine, enemy) {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetTrigger("Idle");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void Exit()
    {
        
    }
}