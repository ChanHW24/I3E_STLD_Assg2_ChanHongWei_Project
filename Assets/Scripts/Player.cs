/*
 * Author: Chan Hong Wei
 * Date: 28/06/2024
 * Description: 
 * The Player script that controls the interaction, raycast and health
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;

    [SerializeField]
    private AudioClip hurtAudio;

    [SerializeField]
    private AudioClip healAudio;

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    // The player health
    public int maxHealth = 100;
    public int currentHealth;

    public GameManager gameManager; // load in game manager cs script
    private bool isDead;

    // Reference to the health bar
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        // Raycast script
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            Debug.Log(hitInfo.transform.name + " was touched");
        }

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Dead");
            gameManager.GameOver(); // Display game over menu
        }

    }

    // Damage function for the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        AudioSource.PlayClipAtPoint(hurtAudio, transform.position, 1f);
        healthBar.SetHealth(currentHealth);
    }

    public void RestoreHealth(int amount)
    {
        currentHealth += amount;
        AudioSource.PlayClipAtPoint(healAudio, transform.position, 1f);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    /// <summary>
    /// Update the player's current Interactable
    /// </summary>
    /// <param name="newInteractable">The interactable to be updated</param>
    public void UpdateInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }

    /// <summary>
    /// Callback function for the Interact input action
    /// </summary>
    void OnInteract()
    {
        // Check if the current Interactable is null
        if (currentInteractable != null)
        {
            // Interact with the object
            currentInteractable.Interact(this);
        }
    }
}