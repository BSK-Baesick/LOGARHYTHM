
//TODO Make a logic that if the BEAT has been succesfully interact, use that tile in spawning another BEAT in the next spawn point.
// TODO If the BEATLifetime has ended, destroy it and put it into our pool

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the logic on how the BEATz will spawn in the scene
/// </summary>

    [RequireComponent(typeof(CircleCollider2D))]
public class SpawnPattern : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
    }

    // Class Variables
    List<Transform> spawnPoints;
    int spawnPointIndex = 0;

    //Cached References
    WaveConfiguration waveConfiguration;

    // Use this for initialization
    void Start()
    {
        // Local Variable
        // 1.) The Spawn Points
        spawnPoints = waveConfiguration.GetWaypoints();
    }



    // Update is called once per frame
    void Update()
    {
        // Spawn on the other point
        Blink();
    }



    public void SetWaveConfiguration(WaveConfiguration waveConfig)

    {
        // We assign the wave configuration into the waveConfig
        this.waveConfiguration = waveConfig;
    }



    private void Blink()
    {
        // Check if the spawn point index is less than or equal to the spawn points count minus 1
        if (spawnPointIndex <= spawnPoints.Count - 1)

        {
            // Local Variables
            //1.) The transform position of the indexed spawn point
            var targetPosition = spawnPoints[spawnPointIndex].transform.position;

            /*
            var movementThisFrame = waveConfiguration.GetMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards

                (transform.position, targetPosition, movementThisFrame);
            */

            transform.position = targetPosition;

            if (transform.position == targetPosition)

            {
                spawnPointIndex++;
            }
        }
    }
}
