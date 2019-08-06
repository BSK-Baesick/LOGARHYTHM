using UnityEngine;
using HedgehogTeam.EasyTouch;

/// <summary>
/// This script handles the Starting BEAT game logic.
/// </summary>

public class StartingBEAT : MonoBehaviour
{

    // Configuration Parameters
    [Header("Starting BEAT Components")]
    [SerializeField] AudioClip levelSoundtrack = null;

    // Subscribe
    private void OnEnable()
    {
        EasyTouch.On_SimpleTap += EasyTouch_On_SimpleTap;
    }

    // Unsubscribe
    private void OnDisable()
    {
        EasyTouch.On_SimpleTap -= EasyTouch_On_SimpleTap;
    }

    private void OnDestroy()
    {
        EasyTouch.On_SimpleTap -= EasyTouch_On_SimpleTap;
    }

    public void EasyTouch_On_SimpleTap(Gesture gesture)
    {
        // Check if we have tap the Starting BEAT
        if (gesture.pickedObject == this.gameObject)
        {
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

    // Start is called before the first frame update
    void Start()
    {
        //  Set the coordinates of the Starting BEAT at the origin of the game world.
        transform.position = new Vector2(0, 0);
    }
}
