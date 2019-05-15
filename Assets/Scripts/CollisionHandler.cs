using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    bool isDebug = false;

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isDebug)
        {
            StartDeathSequence();
        }
    }

    private void StartDeathSequence()
    {
        print("Player Triggered Something!");
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
