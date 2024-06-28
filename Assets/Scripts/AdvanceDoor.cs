/*
 * Author: Chan Hong Wei
 * Date: 29/06/2024
 * Description: 
 * The door that opens when the player is near it and presses the interact button.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceDoor : Interactable
{

    [SerializeField]
    private AudioSource openAudio;
    public GameObject openUpText;

    // for door lerp time
    public float openDuration;
    float currentDuration;
    bool opening = false;
    Vector3 startRotation;
    Vector3 targetRotation;

    /// <summary>
    /// Flags if the door is open
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Flags if the door is locked
    /// </summary>
    bool locked = false;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the obejct entering the trigger has the "Player" tag
        if (other.gameObject.tag == "Player")
        {
            openUpText.SetActive(true); //Remove pick up text
            // Store the current player
            currentPlayer = other.gameObject.GetComponent<Player>();

            // Update the player interactable to be this door.
            UpdatePlayerInteractable(currentPlayer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the obejct exiting the trigger has the "Player" tag
        if (other.gameObject.tag == "Player")
        {
            openUpText.SetActive(false); //Remove pick up text
            // Remove the player Interactable
            RemovePlayerInteractable(currentPlayer);

            // Set the current Player to null
            currentPlayer = null;
        }
    }

    /// <summary>
    /// Handles the door's interaction
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the door</param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);

        // Call the OpenDoor() function
        OpenDoor();
        // Plays sound effect
        openAudio.Play();
    }

    /// <summary>
    /// Handles the door opening 
    /// </summary>
    public void OpenDoor()
    {
        // Door should open only when it is not locked
        // and not already opened.
        if (!locked && !opened)
        {
            // Cannot directly modify the transform rotation.
            // transform.eulerAngles.y += 90f;

            startRotation = transform.eulerAngles;

            targetRotation = startRotation;

            // Add 90 degrees to the y axis rotation
            targetRotation.y += 90f;

            // Set the opened bool to true
            opening = true;
        }
    }

    /// <summary>
    /// Sets the lock status of the door.
    /// </summary>
    /// <param name="lockStatus">The lock status of the door</param>
    public void SetLock(bool lockStatus)
    {
        // Assign the lockStatus value to the locked bool.
        locked = lockStatus;
    }

    private void Update()
    {
        if (opening)
        {
            currentDuration += Time.deltaTime;
            float t = currentDuration / openDuration;
            transform.eulerAngles = Vector3.Lerp(startRotation, targetRotation, t);

            if (currentDuration >= openDuration)
            {
                currentDuration = 0f;
                opening = false;
                transform.eulerAngles = targetRotation;
                opened = true;
            }
        }
    }
}
