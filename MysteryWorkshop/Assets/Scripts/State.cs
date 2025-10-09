namespace DefaultNamespace
{
    public class State
    {
        protected readonly StateMachine StateMachine;
        protected readonly TeacherGeneral Teacher;

        protected State(StateMachine stateMachine, TeacherGeneral teacher)
        {
            StateMachine = stateMachine;
            Teacher = teacher;
        }
        
        
        public virtual void Enter()
        {
            
        }
        public virtual void Update()
        {
            
        }
        
        public virtual void LateUpdate()
        {
            
        }
        
        public virtual void FixedUpdate()
        {
            
        }
        
        public virtual void Exit()
        {
            
        }
    }
}