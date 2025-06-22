using UnityEngine;

namespace DeepSpace.Ship
{
    [CreateAssetMenu(fileName = "ShipMovementData", menuName = "ScriptableObjects/Ship/ShipMovementData")]
    public class ShipMovementData : ScriptableObject
    {
        [Header("MoveData")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float moveRange;
        [SerializeField] private Vector3 rotateRange;
        [Header("CameraPointData")]
        [SerializeField] private Vector3 cameraPositionOffset;
        [SerializeField] private Vector2 cameraPositionEffect;
        [SerializeField] private float cameraRotationSpeed;

        public float MoveSpeed => moveSpeed;
        public float RotateSpeed => rotateSpeed;
        public float MoveRange => moveRange;
        public Vector3 RotateRange => rotateRange;
        public Vector3 CameraPositionOffset => cameraPositionOffset;
        public Vector2 CameraPositionEffect => cameraPositionEffect;
        public float CameraRotationSpeed => cameraRotationSpeed;
        public float SqrMoveRange { get { return MoveRange * MoveRange; } }
    }
}
