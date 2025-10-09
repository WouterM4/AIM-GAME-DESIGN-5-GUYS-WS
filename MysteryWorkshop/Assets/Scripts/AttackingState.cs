using UnityEngine;

namespace DefaultNamespace
{
    public class AttackingState : State
    {
        public AttackingState(StateMachine stateMachine, TeacherGeneral teacher) : base(stateMachine, teacher)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter");
            Teacher.TeacherBehaviour.StartAttackingTarget();
        }

        public override void Update()
        {
            if (!Teacher.TeacherBehaviour.TargetInRange()) StateMachine.SetState(Teacher.States.ChasingState);
        }

        public override void Exit()
        {
            Teacher.TeacherBehaviour.StopAttackingTarget();
        }
    }
}