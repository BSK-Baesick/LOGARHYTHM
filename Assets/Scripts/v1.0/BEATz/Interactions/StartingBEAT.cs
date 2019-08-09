using UnityEngine;

/// <summary>
/// This script handles the Starting BEAT game logic.
/// </summary>

public class StartingBEAT : MonoBehaviour
{

    // Configuration Parameters
    [Header("Starting BEAT Components")]
    [SerializeField] AudioClip levelSoundtrack = null;

    // Cached References
    GameManager gameManager;
    SpawnManager spawnManager;

    private void Awake()
    {
        // Initialize any component references
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    public void OnStartingTap()
    {

        // Start the game
        gameManager.hasThePartyStarted = true;

        // Spawn BEATz
        spawnManager.SpawnBEATzRoutine();

        // Play the level soundtrack
        if (levelSoundtrack != null)
            {
                var cameraPos = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(levelSoundtrack, cameraPos);
            }

            // Destroy this gameObject
            Destroy(gameObject);
    }
}
