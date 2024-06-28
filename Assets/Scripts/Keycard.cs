/*
 * Author: Chan Hong Wei
 * Date: 29/06/2024
 * Description: 
 * The script for the key to the advance door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : Interactable
{
    /// <summary>
    /// The door that this key card unlocks
    /// </summary>
    public AdvanceDoor linkedDoor;

    public GameObject pickUpText;

    Material[] matArray = new Material[] { /* your materials here */ };

    private void Start()
    {
        // Check if there is a linked door
        if (linkedDoor != null)
        {
            // Lock the door that is linked
            linkedDoor.SetLock(true);
        }
    }

    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        Collect();
    }

    public void Collect()
    {
        // Tell the door to unlock itself.
        pickUpText.SetActive(false); //Remove pick up text
        linkedDoor.SetLock(false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if it's the Player colliding with the keycard
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.SetActive(true); //Remove the pick up text
            currentPlayer = collision.gameObject.GetComponent<Player>();
            UpdatePlayerInteractable(currentPlayer);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        // Check if the object that
        // stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.SetActive(false); //Remove pick up text
            RemovePlayerInteractable(currentPlayer);
            currentPlayer = null;
        }
    }

}