using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform ShipCamPos;
    [SerializeField] private float followMoveSpeed;
    [SerializeField] private float followRotationSpeed;

    Vector3 moveDir;
    Vector3 rotationDir;

    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, ShipCamPos.position, followMoveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, ShipCamPos.rotation, followRotationSpeed * Time.deltaTime);
    }
}
