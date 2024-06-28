/*
 * Author: Chan Hong Wei
 * Date: 28/06/2024
 * Description: 
 * This script control the game over menu UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public GameObject gameOverBackgroundImage;

    public static GameManager instance;

    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        if (instance == null) // Checking if there is any GameManager.
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Put GameManager into the DontDestroyOnLoad
        }
        else if (instance != null && instance != this) // If there is a Gamemanager. Destroy the spare GameManager
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
    }

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
