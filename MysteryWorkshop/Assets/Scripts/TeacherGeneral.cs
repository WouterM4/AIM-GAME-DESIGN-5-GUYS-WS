using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(TeacherBehaviour))]
    public class TeacherGeneral : MonoBehaviour
    {
        private StateMachine _stateMachine;
        public TeacherStateCollection States { get; private set; }
        public TeacherBehaviour TeacherBehaviour { get; private set; }
        
        private void Awake()
        {
            TeacherBehaviour = GetComponent<TeacherBehaviour>();
        }

        private void Start()
        {
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            _stateMachine = new StateMachine();
            States = new TeacherStateCollection(_stateMachine, this);
            _stateMachine.Initialize(States.PatrollingState);
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
            Debug.Log(_stateMachine.CurrentState);
        }

        private void LateUpdate()
        {
            _stateMachine.CurrentState.LateUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.FixedUpdate();
        }
    }
}