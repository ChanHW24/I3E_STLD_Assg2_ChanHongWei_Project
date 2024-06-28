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
        targetPlayer = thePlayer.gameObject.GetComponent<StarterAssets.FirstPersonController>();
        // Assuming you have a reference to the GameObject with the FirstPersonController component
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