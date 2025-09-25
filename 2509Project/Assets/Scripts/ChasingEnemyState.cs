using UnityEngine;

public class ChasingEnemyState : EnemyState
{
    public ChasingEnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
    
    public override void Enter()
    {
        
    }

    public override void Update()
    {
        LookAtPlayer();
        MoveTowardsPlayer();
        UpdateState();
    }

    private void MoveTowardsPlayer()
    {
        var newPos = Vector3.MoveTowards(Enemy.transform.position, Enemy.player.transform.position, Enemy.moveSpeed * Time.deltaTime);
        Enemy.Rb.MovePosition(newPos);
    }

    private void LookAtPlayer()
    {
        Enemy.transform.LookAt(Enemy.player.transform);
    }

    private void UpdateState()
    {
        if (Vector3.Distance(Enemy.transform.position, Enemy.player.transform.position) > Enemy.attackRange) return;
        EnemyStateMachine.SetState(Enemy.AttackingState);
    }

    public override void FixedUpdate()
    {
        
    }

    public override void Exit()
    {
        
    }
}