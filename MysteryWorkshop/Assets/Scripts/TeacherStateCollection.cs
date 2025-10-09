namespace DefaultNamespace
{
    public class TeacherStateCollection
    {
        public readonly PatrollingState PatrollingState;
        public readonly ChasingState ChasingState;

        public TeacherStateCollection(StateMachine stateMachine, TeacherGeneral teacher)
        {
            PatrollingState = new PatrollingState(stateMachine, teacher);
            ChasingState = new ChasingState(stateMachine, teacher);
            
        }
    }

}