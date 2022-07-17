using System;
using UnityEngine;

public static class Events
{
    public static Action<ShakeMode> onCameraShake;
    public static Action<Meteor> onDisableMeteor;
    public static Action onEnableMeteor;
}
