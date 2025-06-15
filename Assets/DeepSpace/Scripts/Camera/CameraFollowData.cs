using UnityEngine;

namespace DeepSpace.Camera
{
    [CreateAssetMenu(fileName = "CameraFollowData", menuName = "ScriptableObjects/Camera/CameraFollowData")]
    public class CameraFollowData : ScriptableObject
    {
        [field: SerializeField] public float FollowMoveSpeed { get; private set; }
        [field: SerializeField] public float FollowRotationSpeed { get; private set; }
        [field: SerializeField] public float MaxOffset { get; private set; } = 1;

        public float SqrMaxOffset { get { return MaxOffset * MaxOffset; } }
    }
}
