using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public Spawner spawn;
    public scoreTracker1 scores;
    public int score;
    public bool pause;
    public bool softPause;
    public bool dead;
    public int storyScore = 0;
    public int storyChoice = 0;
    public int storyProgression = 0;
    public GameObject[] storyText;
    public GameObject[] storyButton;
    public GameObject milanHead;
    public Transform milanSpawn;
    public int currentText;
    // Start is called before the first frame update
    void Start()
    {
        scores = GameObject.Find("score1").GetComponent<scoreTracker1>();
        initialStory();
    }

    // Update is called once per frame
    void Update()
    {
        score = scores.score2;
        progessionCheck();
        if(dead = true)
        {
            softPause = true;
            pause = true;

        }
    }

    void progessionCheck()
    {
        if(score >= 50 && storyProgression == 1)
        {
            storyDecision1();

        }
        if (score >= 100 && storyProgression == 2)
        {
            storyDecision2();

        }
        if (score >= 200 && storyProgression == 3)
        {
            storyDecision3();

        }
    }
    void initialStory()
    {
        softPause = true;
        pause = true;
        storyButton[0].SetActive(true);
        storyButton[1].SetActive(true);
        storyText[0].SetActive(true);
        storyProgression += 1;
    }

    void storyDecision1()
    {
        softPause = true;
        if (GameObject.FindWithTag("Enemy") != null && GameObject.FindWithTag("Enemy Bullets") != null && GameObject.FindWithTag("Enemy Bullets 1") != null && GameObject.FindWithTag("Enemy Bullets 2") != null)
        {
            Debug.Log("help");
            return;
        }
        else
        {
            Debug.Log("buttons");
            storyButton[0].SetActive(true);
            storyButton[1].SetActive(true);
            storyText[storyChoice].SetActive(true);
            currentText = storyChoice;
            pause = true;
        }

    }

    void storyDecision2()
    {
        softPause = true;
        if (GameObject.FindWithTag("Enemy") != null)
        {
            return;
        }
        else
        {
            Debug.Log("buttons");
            storyButton[0].SetActive(true);
            storyButton[1].SetActive(true);
            storyText[storyChoice].SetActive(true);
            currentText = storyChoice;
            pause = true;
        }

    }
    void storyDecision3()
    {
        softPause = true;
        if (GameObject.FindWithTag("Enemy") != null)
        {
            return;
        }
        else if(storyChoice != 4)
        {
            pause = true;
            storyText[5].SetActive(true);
            Instantiate(milanHead, milanSpawn.position, milanSpawn.rotation);
            
        }
        else
        {
            Debug.Log("buttons");
            storyButton[0].SetActive(true);
            storyButton[1].SetActive(true);
            storyText[6].SetActive(true);
            currentText = 6;
            pause = true;
        }

    }
    public void yesTrigger()
    {
        storyScore += 1;
        storyButton[0].SetActive(false);
        storyButton[1].SetActive(false);
        storyText[currentText].SetActive(false);
        pause = false;
        softPause = false;
        storyProgression += 1;

    }

    public void noTrigger()
    {
        storyScore -= 2;
        storyButton[0].SetActive(false);
        storyButton[1].SetActive(false);
        storyText[currentText].SetActive(false);
        pause = false;
        softPause = false;
        storyProgression += 1;
    }

}
