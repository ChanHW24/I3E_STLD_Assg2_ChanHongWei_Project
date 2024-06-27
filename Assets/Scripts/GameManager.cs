/*
 * Author: Chan Hong Wei
 * Date: 28/06/2024
 * Description: 
 * This script control the game over menu UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public GameObject gameOverBackgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenuUI.SetActive(false); // Close pause menu
        gameOverBackgroundImage.SetActive(false); // Close background image
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverMenuUI.SetActive(true); // Show game over menu
        gameOverBackgroundImage.SetActive(true); // Show background image
        Time.timeScale = 0f; // Freeze time
        Cursor.visible = true; // Show cursor
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
    }
}
