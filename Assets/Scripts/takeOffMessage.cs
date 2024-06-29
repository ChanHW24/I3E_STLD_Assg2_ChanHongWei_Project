/*
 * Author: Chan Hong Wei
 * Date: 29/06/2024
 * Description: 
 * This script triggers a pop up message
 */using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class takeOffMessage : PopUpMessage
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.currentScore >= 4)
        {
            base.OnTriggerEnter(other);
        }
    }


}
