using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker1 : MonoBehaviour
{
    public Text scoreText;
    public int score2 = 0;

    void Update()
    {
        scoreText.text = "Score: " + score2;
    }
}