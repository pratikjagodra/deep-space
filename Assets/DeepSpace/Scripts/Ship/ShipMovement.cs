using Unity.Mathematics;
using UnityEngine;

namespace DeepSpace.Ship
{
    [RequireComponent(typeof(ShipInputHandler))]
    [RequireComponent(typeof(Rigidbody))]
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private ShipMovementData movementData;
        [SerializeField] private ShipCameraPoint cameraPoint;

        private ShipInputHandler shipInput;

        private Vector3 shipTargetPos = new Vector3();
        private Vector3 shipPreviousPos = new Vector3();
        private Vector3 shipTargetRotation = new Vector3();

        void Awake()
        {
            shipInput = GetComponent<ShipInputHandler>();
        }

        private void Start()
        {
            shipTargetPos = transform.position;
        }

        private void Update()
        {
            RotateShip(shipInput.MoveInput);
            MoveShip(GetMoveInputFromRotation());
            UpdateCameraPoint(GetMovementDelta());
        }

        private void MoveShip(Vector2 moveInput)
        {
            shipPreviousPos = transform.position;
            shipTargetPos.x = transform.position.x + (Time.deltaTime * moveInput.x * movementData.MoveSpeed);
            shipTargetPos.y = transform.position.y + (Time.deltaTime * moveInput.y * movementData.MoveSpeed);
            if (shipTargetPos.sqrMagnitude > movementData.SqrMoveRange)
                shipTargetPos = shipTargetPos.normalized * movementData.MoveRange;
            transform.position = shipTargetPos;
        }

        private void RotateShip(Vector2 rotateInput)
        {
            shipTargetRotation.x = -rotateInput.y * movementData.RotateRange.x;
            shipTargetRotation.y = rotateInput.x * movementData.RotateRange.y;
            shipTargetRotation.z = -rotateInput.x * movementData.RotateRange.z;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(shipTargetRotation), movementData.RotateSpeed * Time.deltaTime);
        }

        private Vector2 GetMoveInputFromRotation()
        {
            Vector2 moveInput = Vector2.zero;
            float zRot = transform.rotation.eulerAngles.z;
            if (zRot > 180) zRot -= 360f;
            else if (zRot < -180) zRot += 360f;
            float xRot = transform.rotation.eulerAngles.x;
            if (xRot > 180) xRot -= 360f;
            else if (xRot < -180) xRot += 360f;
            moveInput.x = -math.remap(-movementData.RotateRange.z, movementData.RotateRange.z, -1f, 1f, zRot);
            moveInput.y = -math.remap(-movementData.RotateRange.x, movementData.RotateRange.x, -1f, 1f, xRot);
            return moveInput;
        }

        private Vector2 GetMovementDelta()
        {
            return transform.position - shipPreviousPos;
        }

        private void UpdateCameraPoint(Vector2 moveInput)
        {
            if (cameraPoint == null) return;
            var targetCamPosition = transform.position + movementData.CameraPositionOffset;
            targetCamPosition += Vector3.right * moveInput.x * movementData.CameraPositionEffect.x;
            targetCamPosition += Vector3.up * moveInput.y * movementData.CameraPositionEffect.y;

            var targetCamRotation = Quaternion.Lerp(Quaternion.identity, transform.rotation, (moveInput.magnitude * movementData.CameraRotationSpeed) / (Time.deltaTime * movementData.MoveSpeed));
            cameraPoint.UpdateCameraPoint(targetCamPosition, targetCamRotation);
        }
    }
}
