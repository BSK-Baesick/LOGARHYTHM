using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

/// <summary>
/// This script handles the Single Tap BEAT game logic.
/// </summary>
public class SingleTapBEAT : MonoBehaviour
{
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
            // Destroy this gameObject
            Destroy(this.gameObject);
        }
    }
}
