using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public static float moveSpeed = 8f;
    public static float spawnZPos = 70f;

    [SerializeField] float spawnPerSec = 4f;
    [SerializeField] private Meteor[] meteorPool;

    private int meteorPoolIndex;
    private int meteorPoolLength;

    private float spawnRate;
    private float timeSpent;

    private void OnEnable()
    {
        Events.onDisableMeteor += OnDisableMeteor;
    }

    private void OnDisable()
    {
        Events.onDisableMeteor -= OnDisableMeteor;
    }

    private void Start()
    {
        meteorPoolLength = meteorPool.Length;
        spawnRate = 1f / spawnPerSec;
    }

    private void Update()
    {
        if(timeSpent < spawnRate)
        {
            timeSpent += Time.deltaTime;
        }
        else
        {
            timeSpent = 0;
            SpawnMeteor();
        }
    }

    private void OnDisableMeteor(Meteor meteor)
    {
        meteor.Deactivate();
    }

    private void SpawnMeteor()
    {
        meteorPool[meteorPoolIndex].Activate();
        IncreaseMeteorPoolIndex();
    }

    private void IncreaseMeteorPoolIndex()
    {
        meteorPoolIndex++;
        if (meteorPoolIndex >= meteorPoolLength)
            meteorPoolIndex = 0;
    }
}
