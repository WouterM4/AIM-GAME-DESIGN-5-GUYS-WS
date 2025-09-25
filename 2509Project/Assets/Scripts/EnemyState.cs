public abstract class EnemyState
{
    protected readonly Enemy Enemy;
    protected readonly EnemyStateMachine EnemyStateMachine;

    protected EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        Enemy = enemy;
        EnemyStateMachine = enemyStateMachine;
    }
    
    public virtual void Enter()
    {
        
    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
