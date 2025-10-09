namespace DefaultNamespace
{
    public class PatrollingState : State
    {
        public PatrollingState(StateMachine stateMachine, TeacherGeneral teacher) : base(stateMachine, teacher)
        {
        }

        public override void Update()
        {
            if (SeePlayer()) StateMachine.SetState(Teacher.States.ChasingState);
            if (Teacher.TeacherBehaviour.ReachDestination()) Teacher.TeacherBehaviour.MoveTo(Teacher.TeacherBehaviour.NextPatrollingDestination());
        }
        
        private bool SeePlayer()
        {
            return false;
        }
    }
}