/*
 * Author: Chan Hong Wei
 * Date: 29/06/2024
 * Description: 
 * This script triggers the shuttle door to close.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleDoor : AdvanceDoor
{
    public override void OpenDoor()
    {
        if (!locked && !opened && GameManager.instance.currentScore >= 4)
        {
            startRotation = transform.eulerAngles;
            targetRotation = startRotation;
            targetRotation.z += 16f; // Rotate along the z axis for shuttle door
            opening = true;
        }
        
    }
}
