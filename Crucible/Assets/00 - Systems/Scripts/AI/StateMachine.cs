using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    public string CurrentStateDebug = "None";
    
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        CurrentStateDebug = newState.name;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}