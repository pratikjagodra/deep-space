using UnityEngine;
using DeepSpace.Ship;

namespace DeepSpace.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraFollowData followData;

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, ShipCameraPoint.GetPosition(), followData.FollowMoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, ShipCameraPoint.GetRotation(), followData.FollowRotationSpeed * Time.deltaTime);
        }
    }
}
