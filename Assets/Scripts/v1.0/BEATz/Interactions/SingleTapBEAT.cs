using UnityEngine;

/// <summary>
/// This script handles the Single Tap BEAT game logic.
/// </summary>
/// 
public class SingleTapBEAT : MonoBehaviour
{

    public void OnSingleTapBEAT()
    {
            // Destroy this gameObject
            Destroy(this.gameObject);
    }
}
