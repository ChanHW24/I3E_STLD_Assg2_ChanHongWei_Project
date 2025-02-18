/*
 * Author: Chan Hong Wei
 * Date: 24/06/2024
 * Description: 
 * The Collectible will destroy itself after being collected.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;

    public GameObject PickUpText;

    public int myScore = 1;

    void Start()
    {
        PickUpText.SetActive(false);
    }

    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    public virtual void Collected()
    {
        //Plays a sound when item is collected
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

        //Remove pick up text
        PickUpText.SetActive(false);

        // Destroy the attached GameObject
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the collectibles interaction.
    /// Increase the player's score and destroy itself
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.IncreaseScore(myScore);
        Collected();
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>
    public void OnCollisionEnter(Collision collision)
    {
        // Check if the object that
        // touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true); //Remove the pick up text
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
            PickUpText.SetActive(false); //Remove pick up text
            RemovePlayerInteractable(currentPlayer);
            currentPlayer = null;
        }
    }


}