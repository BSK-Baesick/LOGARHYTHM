using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartingBEAT : MonoBehaviour
{

    // Configuration Parameters
    // 1.) The Starting BEAT that we will be using in the level
    [SerializeField] GameObject startingBEAT = null;

    // Start is called before the first frame update
    void Start()
    {
        // Local Variable
        // 1.) The starting poistion of the Starting BEAT in the game.
        Vector2 startingPosition = new Vector2(0, 0);

        // Spawn the Starting BEAT at the start of the game
        Instantiate(startingBEAT, startingPosition, Quaternion.identity);
    }
}
