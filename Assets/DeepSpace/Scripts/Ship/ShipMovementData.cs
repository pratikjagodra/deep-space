using UnityEngine;

namespace DeepSpace.Ship
{
    [CreateAssetMenu(fileName = "ShipMovementData", menuName = "ScriptableObjects/Ship/ShipMovementData")]
    public class ShipMovementData : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
        [field: SerializeField] public float MoveRange { get; private set; }
        [field: SerializeField] public Vector3 RotateRange { get; private set; }
        [field: SerializeField] public Vector3 CameraPositionOffset { get; private set; }
        [field: SerializeField] public Vector2 CameraPositionEffect { get; private set; }
        [field: SerializeField] public float CameraRotationSpeed { get; private set; }

        public float SqrMoveRange { get { return MoveRange * MoveRange; } }
    }
}
