using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    private Enemy _stats;
    private Animator _animator;
    
    
    public DeathState(StateMachine characterStateMachine, Enemy enemy, Animator animator) : base("Death", characterStateMachine)
    {
        _stats = enemy;
        _animator = animator;
    }

    public override void Enter()
    {
        _stats.Die();
        AIManager.Enemies.Remove(_stats);
        _animator.SetTrigger("Die");
        _animator.SetBool("Running", false);
    }
}
