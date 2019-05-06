﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{

    int score = 0;
    Text scoreText;
    [SerializeField] int scorePerHit = 12;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit()
    {
        print("Score Hit Called!");
        score = score + scorePerHit;
        print(score);
        print("score per hit" + scorePerHit);
        scoreText.text = score.ToString();
    }
}
