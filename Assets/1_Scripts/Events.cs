using System;
using UnityEngine;

public static class Events
{
    // Events for Touch input
    public static Func<Vector2> getTouchStartPos;
    public static Func<Vector2> getTouchCurPos;
    public static Func<Vector2> getTouchDeltaPos;
    public static Func<Vector2> getTouchDirection;

    public static Action<ShakeMode> onCameraShake;
}
