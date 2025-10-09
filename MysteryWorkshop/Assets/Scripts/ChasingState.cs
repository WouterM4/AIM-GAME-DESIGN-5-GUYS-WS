namespace DefaultNamespace
{
    public class ChasingState : State
    {
        public ChasingState(StateMachine stateMachine, TeacherGeneral teacher) : base(stateMachine, teacher)
        {
        }

        public override void Update()
        {
            if (!Teacher.TeacherBehaviour.SeePlayer(Teacher.TeacherBehaviour.CurrentTarget)) StateMachine.SetState(Teacher.States.PatrollingState);
            if (Teacher.TeacherBehaviour.TargetInRange()) StateMachine.SetState(Teacher.States.AttackingState);
            Teacher.TeacherBehaviour.MoveTo(Teacher.TeacherBehaviour.CurrentTarget.transform.position);
        }
        
    }
}