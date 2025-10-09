using DefaultNamespace;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public void Initialize(State initialState)
    {
        CurrentState = initialState;
        initialState.Enter();
    }

    public void SetState(State state)
    {
        CurrentState.Exit();
        CurrentState = state;
        state.Enter();
    }
}