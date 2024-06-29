/*
 * Author: Chan Hong Wei
 * Date: 27/05/2024
 * Description: 
 * Contain script for the treasure box
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : Interactable
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    [SerializeField]
    private AudioClip collectAudio;

    public GameObject OpenUpText;

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Plays a sound when item is touched
            AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
            SpawnCollectible();
            Destroy(gameObject);
        }
    }
    */

    private void Start()
    {
        OpenUpText.SetActive(false);
    }

    public virtual void Collected()
    {
        //Plays a sound when item is collected
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);


        // Spawn Key
        SpawnCollectible();

        //Remove pick up text
        OpenUpText.SetActive(false);

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
            OpenUpText.SetActive(true); //Remove the pick up text
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
            OpenUpText.SetActive(false); //Remove pick up text
            RemovePlayerInteractable(currentPlayer);
            currentPlayer = null;
        }
    }

    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
