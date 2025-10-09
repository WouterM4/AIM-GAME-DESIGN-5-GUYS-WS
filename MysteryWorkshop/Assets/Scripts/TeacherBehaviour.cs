using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TeacherBehaviour : MonoBehaviour
{
    [SerializeField] private TeacherMovementData data;
    [SerializeField] private Transform[] patrolPoints;
    private NavMeshAgent _agentComponent;
    private int _currentPatrollingDestination;
    private bool _returning; 
    public Transform CurrentTarget { get; private set; }
    
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

    public void UpdateCurrentTarget(Transform target)
    {
        CurrentTarget = target;
    }

    public void Attack()
    {
        
    }
}
