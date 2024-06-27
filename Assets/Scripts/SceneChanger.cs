/*
 * Author: Chan Hong Wei
 * Date: 27/05/2024
 * Description: 
 * Contain script to swtich scene when touching game object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public int targetSceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object has the "Player" tag
        if (other.tag == "Player")
        {
            // If it is the player, change scene.
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}