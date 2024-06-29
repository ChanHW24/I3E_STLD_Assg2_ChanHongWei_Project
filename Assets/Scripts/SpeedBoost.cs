/*
 * Author: Chan Hong Wei
 * Date: 27/05/2024
 * Description: 
 * Contain script for the speed boost activation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Collectible
{
    StarterAssets.FirstPersonController targetPlayer;

    public override void Collected()
    {
        // Add powerup specific logic here (e.g., activate powerup)
        ActivatePowerUp();

        // Call the base class Collected method first (important!)
        base.Collected();

    }

    public override void Interact(Player thePlayer)
    {
        targetPlayer = thePlayer.gameObject.GetComponent<StarterAssets.FirstPersonController>(); // Get component from the starter asset
        base.Interact(thePlayer);
    }


    public void ActivatePowerUp()
    {
        // Implement powerup activation logic here
        Debug.Log("Speed Boost Initiated");


        // Modify the movement speed property
        targetPlayer.MoveSpeed = 50.0f;
    }
}