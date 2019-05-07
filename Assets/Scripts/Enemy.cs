using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 100;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

}
