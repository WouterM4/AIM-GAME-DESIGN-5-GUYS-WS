namespace DefaultNamespace
{
    public class PatrollingState : State
    {
        public PatrollingState(StateMachine stateMachine, TeacherGeneral teacher) : base(stateMachine, teacher)
        {
        }

        public override void Update()
        {
            if (Teacher.TeacherBehaviour.SeeAnyPlayer(out var playerTransform))
            {
                Teacher.TeacherBehaviour.UpdateCurrentTarget(playerTransform);
                StateMachine.SetState(Teacher.States.ChasingState);
            }
            if (Teacher.TeacherBehaviour.ReachDestination()) Teacher.TeacherBehaviour.MoveTo(Teacher.TeacherBehaviour.NextPatrollingDestination());
        }
    }
}