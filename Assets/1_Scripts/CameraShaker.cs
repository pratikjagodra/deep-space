using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    [SerializeField] private ShakeMode curShakeMode;
    [Header("Shake Data")]
    [SerializeField] private SOShakeData minorShakeData;
    [SerializeField] private SOShakeData smallShakeData;
    [SerializeField] private SOShakeData mediumShakeData;
    [SerializeField] private SOShakeData largeShakeData;
    [SerializeField] private SOShakeData extremeShakeData;

    private float shakeStrength;
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

    private void OnEnable()
    {
        Events.onCameraShake += ShakeCamera;
    }

    private void OnDisable()
    {
        Events.onCameraShake -= ShakeCamera;
    }

    private void Start()
    {
        SetDirections();
    }

    private void Update()
    {
        if(canShake)
        {
            newPos = Vector3.MoveTowards(camTransform.localPosition, targetPos, Time.deltaTime * shakeSpeed);
            camTransform.localPosition = newPos;

            if (newPos == targetPos)
                targetPos = GetShakeDirection() * shakeStrength;

            shakeDuration -= Time.deltaTime;

            if(shakeDuration < 0)
            {
                canShake = false;
                canReturnToNormal = true;
            }
        }
        else if(canReturnToNormal)
        {
            newPos = Vector3.MoveTowards(camTransform.localPosition, Vector3.zero, Time.deltaTime * shakeSpeed);
            camTransform.localPosition = newPos;

            if(camTransform.localPosition == Vector3.zero)
                canReturnToNormal = false;
        }
    }

    private void ShakeCamera(ShakeMode shakeMode)
    {
        ConfigureShakeData(shakeMode);

        targetPos = GetShakeDirection() * shakeStrength;
        canShake = true;
        canReturnToNormal = false;
    }

#if UNITY_EDITOR
    [ContextMenu("ShakeInfinitely")]
    private void ShakeInfinitely()
    {
        ConfigureShakeData(curShakeMode);
        shakeDuration = Mathf.Infinity;
        targetPos = GetShakeDirection() * shakeStrength;
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

    private void ConfigureShakeData(ShakeMode shakeMode)
    {
        curShakeMode = shakeMode;
        switch (curShakeMode)
        {
            case ShakeMode.Minor:
                shakeStrength = minorShakeData.shakeStrength;
                shakeSpeed = minorShakeData.shakeSpeed;
                shakeDuration = minorShakeData.shakeDuration;
                break;

            case ShakeMode.Small:
                shakeStrength = smallShakeData.shakeStrength;
                shakeSpeed = smallShakeData.shakeSpeed;
                shakeDuration = smallShakeData.shakeDuration;
                break;

            case ShakeMode.Medium:
                shakeStrength = mediumShakeData.shakeStrength;
                shakeSpeed = mediumShakeData.shakeSpeed;
                shakeDuration = mediumShakeData.shakeDuration;
                break;

            case ShakeMode.Large:
                shakeStrength = largeShakeData.shakeStrength;
                shakeSpeed = largeShakeData.shakeSpeed;
                shakeDuration = largeShakeData.shakeDuration;
                break;

            case ShakeMode.Extreme:
                shakeStrength = extremeShakeData.shakeStrength;
                shakeSpeed = extremeShakeData.shakeSpeed;
                shakeDuration = extremeShakeData.shakeDuration;
                break;

            default:
                shakeStrength = 0;
                shakeSpeed = 0;
                shakeDuration = 0;
                break;
        }
    }
}
