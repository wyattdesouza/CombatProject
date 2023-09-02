using UnityEngine;

public class MovingToTargetState : AliveState
{
    private AstarAgent _astarAgent;
    private Animator _animator;
    
    public MovingToTargetState(CharacterStateMachine stateMachine, AstarAgent astarAgent, Enemy enemy, Animator animator) : base("MovingToTarget", stateMachine, enemy) {

        _animator = animator;
        _astarAgent = astarAgent;
    }

    public override void Enter()
    {
        _astarAgent.Target = _stats.target.transform;
        _astarAgent.speed = _stats.MoveSpeed;
        _astarAgent.Pathing = true;
        _animator.SetBool("Running", true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_astarAgent.RemainingDistance <= _stats.AttackRange)
        {
            _sm.ChangeState(_sm.attackState);
        }
        _astarAgent.speed = _stats.MoveSpeed;
        _astarAgent.Pathing = true;
    }

    public override void Exit()
    {
      //  _astarAgent.Target = null;
        _astarAgent.speed = 0;
        _animator.SetBool("Running", false);
        _astarAgent.Pathing = false;
    }
}
