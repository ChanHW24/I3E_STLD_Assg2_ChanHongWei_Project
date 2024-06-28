/*
 * Author: Chan Hong Wei
 * Date: 28/06/2024
 * Description: 
 * This script is to heal the player via health collectibles
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int heal; // Amount of health to restore

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null && player.currentHealth != 100)
            {
                player.RestoreHealth(heal);
                Destroy(gameObject); // Destroy the health pickup after it is used
            }
        }
    }
}
