using UnityEngine;

namespace DeepSpace.Ship
{
    public class ShipCameraPoint : MonoBehaviour
    {
        private static Transform CameraPoint { get; set; }

        private void Awake()
        {
            CameraPoint = transform;
        }

        internal void UpdateCameraPoint(Vector3 cameraPosition, Quaternion cameraRotation)
        {
            CameraPoint.position = cameraPosition;
            CameraPoint.rotation = cameraRotation;
        }

        internal static Vector3 GetPosition()
        {
            return CameraPoint == null ? Vector3.zero : CameraPoint.position;
        }

        internal static Quaternion GetRotation()
        {
            return CameraPoint == null ? Quaternion.identity : CameraPoint.rotation;
        }
    }
}
