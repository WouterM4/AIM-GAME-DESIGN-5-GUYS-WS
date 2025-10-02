using System.Collections;
using UnityEngine;

public class AttackingEnemyState : EnemyState
{
    private Coroutine _attackCoroutine;

    public AttackingEnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
    
    public override void Enter()
    {
        _attackCoroutine = Enemy.StartCoroutine(Attack());
    }

    public override void Update()
    {
        Enemy.LookAtPlayer();
        UpdateState();
    }
    
    public override void FixedUpdate()
    {
        
    }

    public override void Exit()
    {
        if (_attackCoroutine == null) return;
        Enemy.StopCoroutine(_attackCoroutine);
        _attackCoroutine = null;
    }
    
    private void UpdateState()
    {
        if (Vector3.Distance(Enemy.transform.position, Enemy.player.transform.position) <= Enemy.attackRange) return;
        EnemyStateMachine.SetState(Enemy.ChasingState);
        
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(Enemy.firstAttackCooldown);
        while (true)
        {
            Enemy.player.TakeDamage(Enemy.damageDealt);
            yield return new WaitForSeconds(Enemy.attackCooldown);
        }
    }
}