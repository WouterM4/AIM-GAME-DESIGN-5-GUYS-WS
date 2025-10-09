namespace DefaultNamespace
{
    public class TeacherStateCollection
    {
        public readonly PatrollingState PatrollingState;
        public readonly ChasingState ChasingState;
        public readonly AttackingState AttackingState;

        public TeacherStateCollection(StateMachine stateMachine, TeacherGeneral teacher)
        {
            PatrollingState = new PatrollingState(stateMachine, teacher);
            ChasingState = new ChasingState(stateMachine, teacher);
            AttackingState = new AttackingState(stateMachine, teacher);
            
            
        }
    }

}