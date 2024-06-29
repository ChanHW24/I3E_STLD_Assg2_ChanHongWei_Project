/*
 * Author: Chan Hong Wei
 * Date: 29/06/2024
 * Description: 
 * This script triggers a spawn event
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] bool destroyOnTriggerEnter;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    public AudioSource audioSource;
    private bool hasPlayedAudio = false; // Flag to track if the audio has been played


    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.currentScore >= 4)
        {
            onTriggerEnter.Invoke();

            // Play audio only if it hasn't been played yet
            if (!hasPlayedAudio)
            {
                audioSource.Play();
                hasPlayedAudio = true; // Set the flag to true after playing the audio
            }

            if (destroyOnTriggerEnter)
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}

