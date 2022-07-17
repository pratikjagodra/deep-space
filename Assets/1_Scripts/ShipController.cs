using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] float moveSpeed = 10f;
    private Rigidbody rb;

    private Vector2 touchDir = Vector2.zero;
    private Vector3 rotateDir = Vector3.zero;
    private Vector3 moveDir = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        touchDir = joystick.UnitRawDirection();

        rotateDir.x = -touchDir.y;
        rotateDir.y = touchDir.x;

        if(rotateDir.x != 0f || rotateDir.y != 0f)
        {
            rb.MoveRotation(rb.rotation * Quaternion.AngleAxis(turnSpeed * Time.fixedDeltaTime, rotateDir));
        }

        moveDir = (rb.rotation * Vector3.forward);
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        // rb.AddForce(moveDir * moveSpeed * Time.fixedDeltaTime, ForceMode.Force);
    }
}
