using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

#pragma warning disable 0649

    [Header("Score Interface")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI targetScoreText;

    [Header("Score System")]
    [SerializeField] int points = 100;
    public int targetScore;

    // Global Variables
    public int Score;

    private void Start()
    {

        if (scoreText != null)
        {
            scoreText.text = "EmoPOINTS COLLECTED: 0";
        }

        if (targetScoreText != null)
        {
            targetScoreText.text = "COLLECT " + targetScore + " EmoPOINTS TO ADVANCE THROUGH THE NEXT LEVEL";
        }

    }

    public void AddScore()
    {
        // Add points to score
        Score += points;

        // Converts scoreText's text component into a string
        scoreText.text = "EmoPOINTS COLLECTED:  " + Score;
    }

    public void SubtractScore()
    {
        // Subtract points to score
        Score -= points * 2;

        // Converts scoreText's text component into a string
        scoreText.text = "EmoPOINTS COLLECTED:  " + Score;
    }

    public void HideTargetScoreText()
    {
        StartCoroutine(AnimateTargetScoreText());
    }

    IEnumerator AnimateTargetScoreText()
    {
        targetScoreText.alpha = 250;
        yield return new WaitForSeconds(.5f);
        targetScoreText.alpha = 200;
        yield return new WaitForSeconds(.5f);
        targetScoreText.alpha = 150;
        yield return new WaitForSeconds(.5f);
        targetScoreText.alpha = 100;
        yield return new WaitForSeconds(.5f);
        targetScoreText.alpha = 50;
        yield return new WaitForSeconds(.5f);
        targetScoreText.alpha = 0;
    }
}
