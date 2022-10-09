using UnityEngine;

public class OrbitalRing : MonoBehaviour
{
    [SerializeField] private Transform orbitCenter;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float orbitSpeed;
    [SerializeField] private float orbitWidth;
    [SerializeField] private float orbitHeight;

    [Header("")]
    [SerializeField] private OrbitalMovement[] orbits;

    private void Start()
    {
        orbits = GetComponentsInChildren<OrbitalMovement>();

        foreach (OrbitalMovement orbit in orbits)
        {
            orbit.SetUp(orbitWidth, orbitHeight);
        }
    }

    private void FixedUpdate()
    {
        foreach (OrbitalMovement orbit in orbits)
        {
            orbit.AddOrbitalForce(orbitCenter, orbitRadius, orbitSpeed);
        }
    }
}
