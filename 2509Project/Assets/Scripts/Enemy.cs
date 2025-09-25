using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public Rigidbody Rb { private set; get; }
    [SerializeField] public PlayerController player;
    [SerializeField] public float moveSpeed = 2;
    [SerializeField] public float attackRange = 3;
    private EnemyStateMachine _enemyStateMachine;
    public ChasingEnemyState ChasingState;
    public WanderingEnemyState WanderingState;
    public AttackingEnemyState AttackingState;
    
    private void Start()
    {
        Rb  = GetComponent<Rigidbody>();
        _enemyStateMachine = new EnemyStateMachine();
        ChasingState = new ChasingEnemyState(this, _enemyStateMachine);
        WanderingState = new WanderingEnemyState(this, _enemyStateMachine);
        AttackingState = new AttackingEnemyState(this, _enemyStateMachine);
        _enemyStateMachine.Initialize(ChasingState);
    }
    
    private void Update()
    {
        _enemyStateMachine.CurrentEnemyState.Update();
    }
}
