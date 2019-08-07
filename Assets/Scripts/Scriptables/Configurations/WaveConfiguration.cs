using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles all the data regarding the spawn pattern
/// </summary>

[CreateAssetMenu(menuName = "BEATz Manager")]
public class WaveConfiguration : ScriptableObject
{

    // Cached References
    [Header("BEAT Information")]
    // 1.) The BEATPrefab that we will be spawning
    [SerializeField] GameObject BEATPrefab = null;
    // 2.) A list of spawn points where we will spawn BEATz
    [SerializeField] GameObject spawnPattern = null;

    [Header("Spawning Attributes")]
    // 1.) How fast the BEATz are spawned
    [SerializeField] float spawnRate = 1f;
    // 2.) Number of BEAT that we will spawn
    [SerializeField] int spawnNumber = 1;
    // 3.)  Until when we will spawn the BEATz
    [SerializeField] float spawnDuration = 1f;

    [Header("Spawning Conditions")]
    // 1.) Spawn BEATz in random position
    [SerializeField] bool randomSpawn = false;
    // 2.) Loop
    [SerializeField] bool loop = false;
    // 3.) Delay at the end of the spawn pattern
    [SerializeField] bool delay = false;
    // 4.) Delay interval after the spawn pattern has ended (Only works if delay is toggled ON)
    [SerializeField] float delayInterval = 1f;

    // TODO spawnPatternList which stores the spawning position of the BEAT
    public List<Transform> GetWaypoints()

    {
        var spawnPoint = new List<Transform>();
        foreach (Transform child in spawnPattern.transform)
        {
            spawnPoint.Add(child);
        }
        return spawnPoint;
    }
    public GameObject GetBEATPrefab()
    {
        return BEATPrefab;
    }

    public float GetSpawnRate()
    {
        return spawnRate;
    }

    public int GetSpawnNumber()
    {
        return spawnNumber;
    }

    public float GetSpawnDuration()
    {
        return spawnDuration;
    }

    public bool GetRandomSpawn()
    {
        return randomSpawn;
    }

    public bool GetLoop()
    {
        return loop;
    }

    public bool GetDelay()
    {
        return delay;
    }

    public float GetDelayInterval()
    {
        return delayInterval;
    }
}
