/*
 * Author: Chan Hong Wei
 * Date: 28/06/2024
 * Description: 
 * This script is to deal damage to the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Player playerHealth; // Call in Player script

    public int damage;

    public HealthBar healthBar; // Reference to the health bar

    public float damageInterval = 1f; // Time between damage applications

    private float nextDamageTime;

    // If player enter the trigger point
    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object has the "Player" tag
        if (other.tag == "Player")
        {
            Debug.Log("Player takes " + damage + " damage.");
            playerHealth.TakeDamage(damage); // load damage function
        }
    }

    // If player stays within the trigger point
    private void OnTriggerStay(Collider other)
    {
        // Check whether the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            if (Time.time >= nextDamageTime)
            {
                Debug.Log("Player takes " + damage + " damage.");
                playerHealth.TakeDamage(damage); // load damage function
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    // If player exits the trigger point
    private void OnTriggerExit(Collider other)
    {
        // Check whether the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Reset nextDamageTime to avoid immediate damage when re-entering
            nextDamageTime = 0f;
        }
    }

    // on collision enter
    public void OnCollisionEnter(Collision collision)
    {
        // Check if the object that
        // touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player takes " + damage + " damage.");
            playerHealth.TakeDamage(damage); // load damage function
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        // Check if the object that
        // stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Reset nextDamageTime to avoid immediate damage when re-entering
            nextDamageTime = 0f;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        // Check if the object that
        // touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time >= nextDamageTime)
            {
                Debug.Log("Player takes " + damage + " damage.");
                playerHealth.TakeDamage(damage); // load damage function
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }


}
