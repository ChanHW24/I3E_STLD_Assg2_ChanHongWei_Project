/*
 * Author: Chan Hong Wei
 * Date: 26/05/2024
 * Description: 
 * Contain script to programme the Pause Menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    public GameObject backgroundImage; // Reference to the background image

    public GameObject healthBar; // Reference to the health bar

    public GameObject gameManager;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Close pause menu
        backgroundImage.SetActive(false); // Close background image

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume game function
    public void Resume()
    {
        Debug.Log("Resume.");
        pauseMenuUI.SetActive(false); // Close pause menu
        backgroundImage.SetActive(false); // Close background image
        healthBar.SetActive(true); // Turn on health bar
        gameManager.SetActive(true); // Turn on game manager
        Time.timeScale = 1f; // Resume time
        GameIsPause = false;
        Cursor.visible = false; // Hide cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor
    }

    // Pause game function
    public void Pause()
    {
        Debug.Log("Pause");
        pauseMenuUI.SetActive(true); // Show pause menu
        backgroundImage.SetActive(true); // Show background image
        healthBar.SetActive(false); // Turn off health bar
        gameManager.SetActive(false); // Turn off game manager
        Time.timeScale = 0f; // Freeze time
        GameIsPause = true;
        Cursor.visible = true; // Show cursor
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
    }

    public void Restart()
    {
        Debug.Log("Restart");
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
