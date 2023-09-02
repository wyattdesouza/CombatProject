using UnityEngine;

public class AttackState : AliveState
{
    private bool midAttack => _animator != null && _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01");
    private AstarAgent _astarAgent;
    private Animator _animator;
    
    public AttackState(CharacterStateMachine stateMachine, Enemy enemy, Animator animator, AstarAgent astarAgent) : base("Attack", stateMachine, enemy) {
        _animator = animator;
        _astarAgent = astarAgent;
    }

    public override void Enter()
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (midAttack)
            return;
        
        //is target out of range
        if (_astarAgent.RemainingDistance > _stats.AttackRange)
        {
            _sm.ChangeState(_sm.MovingToTargetState);
            return;
        }
        
        if (!FacingTarget())
            RotateTowardsTarget();
        else
            _animator.SetTrigger("Attack");
    }

    public override void Exit()
    {
        
    }
    
    private bool FacingTarget()
    {
        //return Vector3.Angle(transform.forward, target.position - transform.position) < 1f;
        //check then angle around the y axis only
        var targetDir = _stats.target.transform.position - _stats.transform.position;
        var forward = _stats.transform.forward;
        targetDir.y = 0;
        forward.y = 0;
        return Vector3.Angle(targetDir, forward) < 1f;
    }
    
    private void RotateTowardsTarget()
    {
        Vector3 direction = (_stats.target.transform.position - _stats.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _stats.transform.rotation = Quaternion.RotateTowards(_stats.transform.rotation, lookRotation, _stats.RotationSpeed);
    }
}