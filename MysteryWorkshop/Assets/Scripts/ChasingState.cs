namespace DefaultNamespace
{
    public class ChasingState : State
    {
        public ChasingState(StateMachine stateMachine, TeacherGeneral teacher) : base(stateMachine, teacher)
        {
        }

        public override void Update()
        {
            Teacher.TeacherBehaviour.MoveTo(Teacher.TeacherBehaviour.CurrentTarget.position);
        }
        
    }
}