using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{

    // Global Variables
    public bool hasStarted = false;

    // Cached Reference
    /* ScoreManager scoreManager;

    private void Start()
    {
        // Sets the scoreManager variable to "ScoreManager.cs" component
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    public void StartTheGameTimer()
    {
        StartCoroutine(StartGameTimer());
    }

    IEnumerator StartGameTimer()
    {

        yield return new WaitForSeconds(196.563f);

            var currentScore = scoreManager.Score;
            var targetScore = scoreManager.targetScore;

            if (currentScore >= targetScore)
            {
                SceneManager.LoadScene("Win Screen");
            }

            else
            {
                SceneManager.LoadScene("Lose Screen");
            }
    } */
}
