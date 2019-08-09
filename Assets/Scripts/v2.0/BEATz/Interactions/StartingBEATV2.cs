using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingBEATV2 : MonoBehaviour
{

    // Configuration Parameters
    [Header("Starting BEAT Components")]
    [SerializeField] AudioClip levelSoundtrack = null;

    // Cached References
    GameManagerV2 gameManagerV2;
    SpawnManager spawnManager;
    // ScoreManager scoreManager;

    private void Awake()
    {
        // Sets the gameManager into a "GameManager.cs" script
        gameManagerV2 = GameObject.Find("Game Manager v2").GetComponent<GameManagerV2>();

        // Sets the spawnManager into a "SpawnManager.cs" script
        // spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        // Sets the scoreManager variable to "ScoreManager.cs" component
        // scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the starting BEAT at the origin
        transform.position = new Vector2(0, 0);
    }

    public void OnTap()
    {

        // The game has started
        gameManagerV2.hasStarted = true;

        // Start the timer
        // gameManagerv2.StartTheGameTimer();

        // Updates the scoreGUI
        // scoreManager.AddScore();

        // Start spawning BEATz
        // spawnManager.StartSpawnRoutine();

        // Hide target score text
        // scoreManager.HideTargetScoreText();

        // Play the level soundtrack
        if (levelSoundtrack != null)
        {
            var cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(levelSoundtrack, cameraPos);
        }

        // Destroy this gameObject
        Destroy(this.gameObject);
    }
}
