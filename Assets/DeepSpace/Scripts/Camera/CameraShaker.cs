using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DeepSpace.Camera
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private Transform camTransform;

        private float shakeOffset;
        private float shakeSpeed;
        private float shakeDuration;
        private bool canShake = false;
        private bool canReturnToNormal = false;

        private int shakeDirNumber = 5;
        private Vector3[] shakeDirections;
        private int dirIndex;
        private int indexOffset = 2;

        private Vector3 targetPos = Vector3.zero;
        private Vector3 newPos = Vector3.zero;

        private void Start()
        {
            SetDirections();
        }

        private void Update()
        {
            if (canShake)
            {
                newPos = Vector3.MoveTowards(camTransform.localPosition, targetPos, Time.deltaTime * shakeSpeed);
                camTransform.localPosition = newPos;

                if (newPos == targetPos)
                    targetPos = GetShakeDirection() * shakeOffset;

                shakeDuration -= Time.deltaTime;

                if (shakeDuration < 0)
                {
                    canShake = false;
                    canReturnToNormal = true;
                }
            }
            else if (canReturnToNormal)
            {
                newPos = Vector3.MoveTowards(camTransform.localPosition, Vector3.zero, Time.deltaTime * shakeSpeed);
                camTransform.localPosition = newPos;

                if (camTransform.localPosition == Vector3.zero)
                    canReturnToNormal = false;
            }
        }

        private void ShakeCamera(float _shakeOffset, float _shakeSpeed, float _shakeDuration)
        {

            shakeOffset = _shakeOffset;
            shakeSpeed = _shakeSpeed;
            shakeDuration = _shakeDuration;

            targetPos = GetShakeDirection() * shakeOffset;
            canShake = true;
            canReturnToNormal = false;
        }

#if UNITY_EDITOR
        [ContextMenu("ShakeInfinitely")]
        private void ShakeInfinitely()
        {
            shakeDuration = Mathf.Infinity;
            targetPos = GetShakeDirection() * shakeOffset;
            canShake = true;
            canReturnToNormal = false;
        }

        [ContextMenu("StopShaking")]
        private void StopShaking()
        {
            canShake = false;
            canReturnToNormal = true;
        }
#endif

        private void SetDirections()
        {
            shakeDirections = new Vector3[shakeDirNumber];

            float angle = 2 * Mathf.PI / shakeDirNumber;

            for (int i = 0; i < shakeDirNumber; i++)
            {
                shakeDirections[i].x = MathF.Cos(i * angle) * 0.01f;
                shakeDirections[i].y = MathF.Sin(i * angle) * 0.01f;
            }

            dirIndex = 0;
        }

        private Vector3 GetShakeDirection()
        {
            indexOffset = Random.Range(0, 10) < 5 ? 2 : 3;

            dirIndex += indexOffset;

            if (dirIndex >= shakeDirNumber)
                dirIndex -= shakeDirNumber;

            return shakeDirections[dirIndex];
        }
    }
}
