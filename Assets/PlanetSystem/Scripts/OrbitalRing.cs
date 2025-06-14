using UnityEngine;

public class OrbitalRing : MonoBehaviour
{
    [SerializeField] private Transform orbitCenter;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float orbitSpeed;
    [SerializeField] private float orbitWidth;
    [SerializeField] private float orbitHeight;

    [Header("")]
    [SerializeField] private Astroid[] astroids;

    private void Start()
    {
        astroids = GetComponentsInChildren<Astroid>();

        foreach (Astroid orbit in astroids)
        {
            orbit.SetUp(orbitWidth, orbitHeight);
        }
    }

    private void FixedUpdate()
    {
        foreach (Astroid orbit in astroids)
        {
            orbit.AddOrbitalForce(orbitCenter, orbitRadius, orbitSpeed);
        }
    }
}
