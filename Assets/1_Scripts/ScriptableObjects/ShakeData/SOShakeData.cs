using UnityEngine;

[CreateAssetMenu(fileName = "ShakeData", menuName = "ScriptableObjects/ShakeData", order = 0)]
public class SOShakeData : ScriptableObject
{
    public float shakeStrength;
    public float shakeSpeed;
    public float shakeDuration;
}