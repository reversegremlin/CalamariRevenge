using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 3f;
    [Tooltip("Effects Prefab on Player")][SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        SendDeathMessage();
        deathFX.SetActive(true);

    }

    private void SendDeathMessage()
    {
        print("Player Dying! Send Message!");
        gameObject.SendMessage("OnPlayerDeath");
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void ReloadScene() //string referenced
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
