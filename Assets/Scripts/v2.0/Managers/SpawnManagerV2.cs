using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerV2 : MonoBehaviour
{

#pragma warning disable 0649

    // Configuration Parameters
    [Header("Objects to be SPAWNED")]
    [SerializeField] GameObject BEAT;

    [Header("Spawner Attributes")]
    [SerializeField] float beatPerSeconds = 1f;

    // Cached References
    GameManagerV2 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the gameManager into a "GameManager.cs" script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerV2>();
    }

    IEnumerator _SpawnBEATzContinuosly()
    {
        // While the game is running
        while (gameManager.hasStarted == true)
        {

            Vector2 position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));

            // Spawn Tap_BEATz in random position
            if (BEAT != null)
            {
                Instantiate(BEAT, position, Quaternion.identity);
            }

            // Wait before spawning a new gameObject
            yield return new WaitForSeconds(beatPerSeconds);
        }
    }

    // Start spawning BEATz
    public void StartSpawnRoutine()
    { 
        StartCoroutine(_SpawnBEATzContinuosly());
    }
   
}
