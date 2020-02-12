using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTracker1 : MonoBehaviour
{
    private int currentScore;
    public Text scoreText;
    public int score2 = 0;
    // Use this for initialization

    void Update()
    {
        scoreText.text = "Score: " + score2;
    }
}