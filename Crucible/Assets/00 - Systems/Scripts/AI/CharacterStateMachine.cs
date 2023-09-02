using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    [HideInInspector]
    public IdleState idleState;
    [HideInInspector]
    public MovingToTargetState MovingToTargetState;
    [HideInInspector]
    public AttackState attackState;
    [HideInInspector] 
    public DeathState deathState;

    private AstarAgent _astarAgent;
    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _astarAgent = GetComponent<AstarAgent>();
        _animator = GetComponent<Animator>();
        _astarAgent.Pathing = false;
        idleState = new IdleState(this, _animator, _enemy);
        MovingToTargetState = new MovingToTargetState(this, _astarAgent, _enemy, _animator);
        attackState = new AttackState(this, _enemy, _animator, _astarAgent);
        deathState = new DeathState(this, _enemy, _animator);
    }
    
    protected override BaseState GetInitialState()
    {
        return MovingToTargetState;
    }
}
