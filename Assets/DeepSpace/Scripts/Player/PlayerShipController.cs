using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Transform ship;
    [SerializeField] private Rigidbody shipRb;

    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizontalRange;
    [SerializeField] private float verticalRange;

    [Space]
    [SerializeField] private float xRotateEffect;
    [SerializeField] private float yRotateEffect;
    [SerializeField] private float zRotateEffect;

    private Vector3 shipTargetPos = new Vector3();
    private Vector3 shipCurrPos = new Vector3();
    private Vector3 shipPrevPos = new Vector3();
    private Vector3 shipDeltaPos = new Vector3();
    private Vector3 shipLocalRotation = new Vector3();

    private void Start()
    {
        shipTargetPos = ship.localPosition;
        shipCurrPos = ship.localPosition;
        shipPrevPos = ship.localPosition;
    }

    private void FixedUpdate()
    {
        shipPrevPos = shipCurrPos;

        shipTargetPos.x = joystick.Horizontal() * horizontalRange;
        shipTargetPos.y = joystick.Vertical() * verticalRange;

        shipCurrPos = Vector3.Lerp(shipCurrPos, shipTargetPos, Time.fixedDeltaTime * moveSpeed);

        ship.localPosition = shipCurrPos;
        shipDeltaPos = shipCurrPos - shipPrevPos;

        shipLocalRotation.x = -shipDeltaPos.y * xRotateEffect * 10f;
        shipLocalRotation.y = shipDeltaPos.x * yRotateEffect * 10f;
        shipLocalRotation.z = -shipDeltaPos.x * zRotateEffect * 10f;

        ship.localEulerAngles = shipLocalRotation;
    }
}
