using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TeacherMovementData", menuName = "ScriptableObjects/TeacherMovementData")]
    public class TeacherMovementData : ScriptableObject
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private bool returnViaRoute;
        [SerializeField] private float viewDistance;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private float viewAngle;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackCooldown;
        [SerializeField] private float attackDamage;
        

        public float MovementSpeed => movementSpeed;
        public bool ReturnViaRoute => returnViaRoute;
        public float ViewDistance => viewDistance;
        public LayerMask PlayerLayer => playerLayer;
        public float ViewAngle => viewAngle;
        public float AttackRange => attackRange;
        public float AttackCooldown => attackCooldown;
        public float AttackDamage => attackDamage;
    }
}