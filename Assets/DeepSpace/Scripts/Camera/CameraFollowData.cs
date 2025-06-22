using UnityEngine;

namespace DeepSpace.Camera
{
    [CreateAssetMenu(fileName = "CameraFollowData", menuName = "ScriptableObjects/Camera/CameraFollowData")]
    public class CameraFollowData : ScriptableObject
    {
        [SerializeField] private float followMoveSpeed;
        [SerializeField] private float followRotationSpeed;
        [SerializeField] private float maxOffset = 1;

        public float FollowMoveSpeed => followMoveSpeed;
        public float FollowRotationSpeed => followRotationSpeed;
        public float MaxOffset => maxOffset;
        public float SqrMaxOffset { get { return maxOffset * maxOffset; } }
    }
}
