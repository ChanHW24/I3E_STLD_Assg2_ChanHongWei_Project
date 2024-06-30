/*
 * Author: Chan Hong Wei
 * Date: 26/05/2024
 * Description: 
 * Contain script to programme the End Menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : HomePage
{

    public AudioSource endSound;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; // Show cursor
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        endSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
