/*
 * Author: Chan Hong Wei
 * Date: 27/06/2024
 * Description: 
 * The door will open when the player moves in front of it
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private AudioSource openAudio;

    /// <summary>
    /// Tracks if the door has been opened
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Callback function for when an object enters the Trigger area
    /// </summary>
    /// <param name="other">The collider that entered the area</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that enters the trigger has the "Player" tag
        // and if the door is not opened
        if (other.gameObject.tag == "Player" && !opened)
            // Open the door
            OpenDoor();
    }

    /// <summary>
    /// Rotates the door open
    /// </summary>
    void OpenDoor()
    {
        // Store the object's rotation
        Vector3 newRotation = transform.eulerAngles;

        // Modify the new variable
        newRotation.y += 90f;

        // Re-assign the value to the object's rotation
        transform.eulerAngles = newRotation;

        // Track that the door has been opened.
        opened = true;

        // Plays sound when door open
        openAudio.Play();
    }
}
