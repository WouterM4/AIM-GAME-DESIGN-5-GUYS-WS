public class EnemyStateMachine
{
    public EnemyState CurrentEnemyState { get; private set; }

    public void Initialize(EnemyState initialEnemyState)
    {
        CurrentEnemyState = initialEnemyState;
        initialEnemyState.Enter();
    }
    
    public void SetState(EnemyState enemyState)
    {
        CurrentEnemyState.Exit();
        CurrentEnemyState = enemyState;
        enemyState.Enter();
    }
}