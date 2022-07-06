using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipInputController : MonoBehaviour
{
    private int fingerId;
    private int touchIndex;
    private Vector2 startPos;
    private Vector2 curPos;
    private Vector2 deltaPos;

    private bool hasValidTouch => fingerId != 1;

    Touch tempTouch;

    private void OnEnable()
    {
        Events.getTouchStartPos += GetTouchStartPos;
        Events.getTouchCurPos += GetTouchCurPos;
        Events.getTouchDeltaPos += GetTouchDeltaPos;
        Events.getTouchDirection += GetTouchDirection;
    }

    private void OnDisable()
    {
        Events.getTouchStartPos -= GetTouchStartPos;
        Events.getTouchCurPos -= GetTouchCurPos;
        Events.getTouchDeltaPos -= GetTouchDeltaPos;
        Events.getTouchDirection -= GetTouchDirection;
    }

    private void Start()
    {
        ResetTouchData();
    }

    private void Update()
    {
        if (Input.touchCount <= 0)
            return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            ConfigureValidTouch(i);
        }

        if (!hasValidTouch)
            return;

        UpdateValidTouchData();
    }

    private void ConfigureValidTouch(int index)
    {
        tempTouch = Input.GetTouch(index);

        if (tempTouch.phase == TouchPhase.Began && !hasValidTouch)
        {
            if (EventSystem.current.IsPointerOverGameObject(tempTouch.fingerId))
                return;

            fingerId = tempTouch.fingerId;
            touchIndex = index;
            startPos = tempTouch.position;

        }
        else if (tempTouch.phase == TouchPhase.Ended || tempTouch.phase == TouchPhase.Canceled && hasValidTouch)
        {
            if (tempTouch.fingerId != fingerId)
                return;

            ResetTouchData();
        }
    }

    private void UpdateValidTouchData()
    {
        tempTouch = Input.GetTouch(touchIndex);
        curPos = tempTouch.position;
        deltaPos = tempTouch.deltaPosition;
    }

    private void ResetTouchData()
    {
        fingerId = -1;
        touchIndex = -1;
        startPos = Vector2.zero;
        curPos = Vector2.zero;
        deltaPos = Vector2.zero;
    }

    private Vector2 GetTouchStartPos()
    {
#if UNITY_EDITOR
        return Vector2.zero;
#else
        return startPos;
#endif
    }

    private Vector2 GetTouchCurPos()
    {
        return curPos;
    }

    private Vector2 GetTouchDeltaPos()
    {
        return deltaPos;
    }

    private Vector2 GetTouchDirection()
    {
#if UNITY_EDITOR
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#else
        return curPos - startPos;
#endif
    }
}
