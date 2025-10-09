using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TeacherBehaviour : MonoBehaviour
{
    [SerializeField] private TeacherMovementData data;
    public TeacherMovementData Data => data;
    [SerializeField] private Transform[] patrolPoints;
    private NavMeshAgent _agentComponent;
    private int _currentPatrollingDestination;
    private bool _returning; 
    public PlayerController CurrentTarget { get; private set; }
    
    private void Awake()
    {
        _agentComponent = GetComponent<NavMeshAgent>();
    }
    
    public void MoveTo(Vector3 destination)
    {
        _agentComponent.SetDestination(destination);
    }

    public bool ReachDestination()
    {
        return _agentComponent.remainingDistance <= _agentComponent.stoppingDistance;
    }

    public Vector3 NextPatrollingDestination()
    {
        var index = _returning ? _currentPatrollingDestination - 1 : _currentPatrollingDestination + 1;
        if (index > patrolPoints.Length - 1 || index < 0)
        {
            if (data.ReturnViaRoute)
            {
                _returning = !_returning;
                return NextPatrollingDestination();
            } 
            _currentPatrollingDestination = 0;
            return patrolPoints[_currentPatrollingDestination].position;
        }
        _currentPatrollingDestination = index;
        return patrolPoints[_currentPatrollingDestination].position;
    }

    public void UpdateCurrentTarget(PlayerController target)
    {
        CurrentTarget = target;
    }

    public void StartAttackingTarget()
    {
        Debug.Log("Started attacking target");
        StartCoroutine(AttackTarget());
    }

    private IEnumerator AttackTarget()
    {
        while (true)
        {
            Debug.Log("Attacking target");
            Attack();
            yield return new WaitForSeconds(data.AttackCooldown);
        }
    }

    private void Attack()
    {
        CurrentTarget.takeDamage(data.AttackDamage);
    }

    public bool TargetInRange()
    {
        return Vector3.Distance(transform.position, CurrentTarget.transform.position) <= data.AttackRange;
    }

    public void StopAttackingTarget()
    {
        StopAllCoroutines();
    }
    
    public bool SeePlayer(PlayerController player)
    {
        var directionToPlayer = (player.transform.position - transform.position).normalized;
        var angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle >= data.ViewAngle / 2f) return false;
        if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer, out var hit,
                data.ViewDistance))
        {
            return hit.collider.gameObject.layer == LayerMask.NameToLayer("Player");
        }
        return true;
    }
    
    public bool SeeAnyPlayer(out PlayerController playerController)
    {
        var playersInRange = Physics.OverlapSphere(transform.position, data.ViewDistance, data.PlayerLayer);
        foreach (var player in playersInRange)
        {
            playerController = player.GetComponent<PlayerController>();
            if (!SeePlayer(playerController) || playerController == null) continue;
            return true;
        }
        playerController = null;
        return false;
    }

    public void LookAtTarget()
    {
        transform.LookAt(CurrentTarget.transform);
    }
}
