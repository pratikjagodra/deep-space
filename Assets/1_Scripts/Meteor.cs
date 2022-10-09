using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 randomForce;

    private Vector3 tempVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);

        transform.localPosition = GetRandomPos();

        randomForce = Vector3.back;

        rb.AddForce(MeteorSpawner.moveSpeed * randomForce.normalized, ForceMode.Impulse);
        rb.angularVelocity = GetRandomAngularVelocity();
    }

    public void Deactivate()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.localPosition = Vector3.zero;

        gameObject.SetActive(false);
    }

    private Vector3 GetRandomPos()
    {
        tempVector.x = Random.Range(-5f, 5f);
        tempVector.y = Random.Range(-5f, 5f);
        tempVector.z = MeteorSpawner.spawnZPos;

        return tempVector;
    }

    private Vector3 GetRandomAngularVelocity()
    {
        tempVector.x = Random.Range(-1f, 1f);
        tempVector.y = Random.Range(-1f, 1f);
        tempVector.z = Random.Range(-1f, 1f);

        return tempVector;
    }
}
