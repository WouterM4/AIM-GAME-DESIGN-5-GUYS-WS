using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TeacherMovementData", menuName = "ScriptableObjects/TeacherMovementData")]
    public class TeacherMovementData : ScriptableObject
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private bool returnViaRoute;
        

        public float MovementSpeed => movementSpeed;
        public bool ReturnViaRoute => returnViaRoute;
    }
}