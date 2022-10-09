using UnityEngine;

public class OrbitalMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;

    private float orbitRadiusOffset;
    private Transform myTransform;
    private Vector3 centerDir;
    private Vector3 centerDirNormal;
    private Vector3 moveDir;
    private Vector3 moveDirNormal;
    private float inForce;

    private void Start()
    {
        myTransform = transform;
    }

    public void AddOrbitalForce(Transform _orbitCenter, float _orbitRadius, float _orbitSpeed)
    {
        _orbitRadius += orbitRadiusOffset;

        centerDir = _orbitCenter.position - myTransform.position;
        centerDirNormal = centerDir.normalized;

        moveDir = Vector3.Cross(centerDir, _orbitCenter.up);
        moveDirNormal = moveDir.normalized;

        myRigidbody.velocity = moveDirNormal * _orbitSpeed;

        inForce = (centerDir.magnitude - _orbitRadius) * _orbitSpeed;
        myRigidbody.AddForce(inForce * Time.fixedDeltaTime * centerDirNormal, ForceMode.VelocityChange);
    }

    public void SetUp(float _orbitWidth, float _orbitHeight)
    {
        orbitRadiusOffset = Random.Range(-1f, 1f) * _orbitWidth;

        transform.position += Vector3.up * Random.Range(-1f, 1f) * _orbitHeight;
    }
}
