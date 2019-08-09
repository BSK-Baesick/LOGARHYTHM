using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTapBEATV2 : MonoBehaviour
{
#pragma warning disable 0649

    // Cached References
    // ScoreManager scoreManager;

    private void Start()
    {
        // Sets the scoreManager variable to "ScoreManager.cs" component
        // scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    public void OnSingleTapBEAT()
    {
        // Updates the scoreGUI
        // scoreManager.AddScore();

        // Destroy this gameObject
        Destroy(this.gameObject);
    }
}
