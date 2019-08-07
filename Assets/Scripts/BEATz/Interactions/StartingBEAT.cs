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
        gameManager = (GameManager)GetComponent(typeof(GameManager));
        spawnManager = (SpawnManager)GetComponent(typeof(SpawnManager));
    }

    // Start is called before the first frame update
    void Start()
    {
        //  Set the coordinates of the Starting BEAT at the origin of the game world.
        transform.position = new Vector2(0, 0);
    }

    public void OnStartingTap()
    {
            // Play the level soundtrack
            if (levelSoundtrack != null)
            {
                var cameraPos = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(levelSoundtrack, cameraPos);
            }

            // Start the game
            gameManager.hasThePartyStarted = true;

            // Spawn BEATz
            spawnManager.StartTheMusic();

            // Destroy this gameObject
            Destroy(gameObject);
    }
}
