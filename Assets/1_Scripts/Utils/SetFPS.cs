using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFPS : MonoBehaviour
{
    [SerializeField] private FPSNumber fPSNumber = FPSNumber._60;

    void Start()
    {
        if(fPSNumber != FPSNumber._Auto)
            Application.targetFrameRate = (int)fPSNumber;
    }
}

public enum FPSNumber
{
    _Auto,
    _24 = 24,
    _30 = 30,
    _60 = 60,
    _90 = 90,
}
