/*
 * Author: Chan Hong Wei
 * Date: 27/05/2024
 * Description: 
 * Contain script to swtich scene when touching game object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : SceneChanger
{
    public override void OnTriggerEnter(Collider other)
    {
        // Check whether the object has the "Player" tag
        if (other.tag == "Player" && GameManager.instance.currentScore >= 4)
        {
            // If it is the player, change scene.
            ChangeScene();
        }
    }
}
