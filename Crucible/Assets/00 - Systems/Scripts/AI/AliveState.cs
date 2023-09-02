public class AliveState : BaseState
{
    protected CharacterStateMachine _sm;
    protected Enemy _stats;
    //private bool alvie;
    
    public AliveState(string name, CharacterStateMachine stateMachine, Enemy enemy) : base(name, stateMachine)
    {
        _sm = stateMachine;
        _stats = enemy;
    }

    public override void Enter()
    {
    }

    public override void UpdateLogic()
    {
        if (_stats.Health <= 0)
        {
            stateMachine.ChangeState(_sm.deathState);
        }
        
    }

    public override void Exit()
    {
    }
}