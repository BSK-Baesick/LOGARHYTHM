
//TODO How can we declare a class variable with a type SpawnPattern to a Coroutine? ANSWER: Use the"EZ Threading Asset".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the BEATz spawning logic.
/// </summary>

public class SpawnManager : MonoBehaviour
{

    // Configuration Parameters
    [Header("Spawner Info")]
    // 1.) The list of Spawn Patterns
    [SerializeField] List<WaveConfiguration> waveConfigs = null;
    //2.) The number of waves passed
    [SerializeField] int waveCount = 0;

    // Cached References
    GameManager gameManager;

    private void Awake()
    {
        // Initialize any component references
        gameManager = gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void SpawnBEATzRoutine()
    {
        StartCoroutine(StartTheMusic());
    }

    // Use this for initialization
    public IEnumerator StartTheMusic()
    {
        // Start spawning BEATz while the game is playing
        do
        {
            yield return StartCoroutine(StartTheParty());
        }
        while (gameManager.hasThePartyStarted);
    }



    private IEnumerator StartTheParty()
    {
        // For each waves that have passed, we will increment the wave index by 1
        for (int waveIndex = waveCount; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];

            // Spawn BEATz in chronological order
            yield return StartCoroutine(SpawnAllBEATzInWave(currentWave));
        }
    }



    private IEnumerator SpawnAllBEATzInWave(WaveConfiguration waveConfig)
    {
        // For each number of BEATz that we will spawn in the scene, we will increment the BEAT count by 1.
        for (int BEATCount = 0; BEATCount < waveConfig.GetSpawnNumber(); BEATCount++)
        {
            // Local Variables
            // 1.) The BEAT that we will be spawning
            var BEAT = waveConfig.GetBEATPrefab();
            // 2.) The BEAT position on spawn
            var BEATPosition = waveConfig.GetWaypoints()[0].transform.position;
            // 3.) Spawn BEAT
            var newBEAT = Instantiate(BEAT, BEATPosition, Quaternion.identity);
            // 4.) The starting time of a spawn pattern.
            int startingSpawnDuration = 0;
            // 5.) The duration time of spawning BEATz
            float endingSpawnDuration = waveConfig.GetSpawnDuration();

            SpawnBEATz(waveConfig, BEAT, newBEAT);

            // Wait before spawning another BEAT.
            yield return new WaitForSeconds(waveConfig.GetSpawnRate());

            BEATCount = SpawnAnotherBEAT(waveConfig, BEATCount, startingSpawnDuration, endingSpawnDuration);

            // If delay is ON, then wait a second.
            if (waveConfig.GetDelay() && endingSpawnDuration == startingSpawnDuration)
            {
                yield return new WaitForSeconds(waveConfig.GetDelayInterval());
            }
        }
    }

    private int SpawnAnotherBEAT(WaveConfiguration waveConfig, int BEATCount, int startingSpawnDuration, float endingSpawnDuration)
    {
        // If BEAT count is greater than the spawn number and the endingSpawnDuration is less than the starting spawn duration..
        if (BEATCount > waveConfig.GetSpawnNumber() && endingSpawnDuration < startingSpawnDuration)
        {
            // Decrement the BEAT Count.
            BEATCount--;
        }

        return BEATCount;
    }

    IEnumerator SpawnBEATz(WaveConfiguration waveConfig, GameObject BEAT, GameObject newBEAT)
    {
        if (!waveConfig.GetRandomSpawn())
        {
            // We instantiate BEATz based on the data that the Spawn Pattern is holding.
            newBEAT.GetComponent<SpawnPattern>().SetWaveConfiguration(waveConfig);

            // Cooldown before spawning another BEAT
            yield return new WaitForSeconds(waveConfig.GetBEATzPerSecond());
        }

        else
        {
            Vector2 randomBEATPosition = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));

            // Spawn BEATz in randon position
            Instantiate(BEAT, randomBEATPosition, Quaternion.identity);

            // Cooldown before spawning another BEAT
            yield return new WaitForSeconds(waveConfig.GetBEATzPerSecond());
        }
    }
}
