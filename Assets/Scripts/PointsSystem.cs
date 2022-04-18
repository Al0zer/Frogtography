using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    public float score;
    public float basePoint = 100;
    public float goodBonus = 20;
    public float perfectBonus = 40;
    public int numOfGood = 0;

    private int displayDuration = 1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI inFrameText;
    public TextMeshProUGUI goodText;
    public TextMeshProUGUI perfectText;
    public TextMeshProUGUI losePointsText;

    void Start()
    {
        inFrameText.enabled = false;
        goodText.enabled = false;
        perfectText.enabled = false;
        losePointsText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + ((int)score).ToString();
    }

    //average photo, displays the word "OK!" on screen
    public void AddAverage()
    {
        score += basePoint;
        inFrameText.enabled = true;

        StartCoroutine(RemoveText(displayDuration, inFrameText));
    }

    //good photo, bonus is added, displays the word "GOOD!"
    public void AddGood()
    {
        score += goodBonus;
        numOfGood += 1;

        //bc the triggers all overlap, i need to first remove the text from the trigger below 
        //before I can display this one 
        //inefficient, i know :/ 
        StartCoroutine(RemoveText(0, inFrameText));
        goodText.enabled = true;
        StartCoroutine(RemoveText(displayDuration, goodText));
    }

    //perfect photo, bonus is added, displays the word "PERFECT!"
    public void AddPerfect()
    {
        score += perfectBonus;

        StartCoroutine(RemoveText(0, goodText));
        perfectText.enabled = true;
        StartCoroutine(RemoveText(displayDuration, perfectText));
    }

    public void LosePoints(float pointsLost)
    {
        score -= pointsLost;
        losePointsText.enabled = true;
        StartCoroutine(RemoveText(displayDuration, losePointsText));
    }

    //removes the "OK/GOOD/PERFECT" text after seconds
    IEnumerator RemoveText(int seconds, TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(seconds);
        text.enabled = false;
    }
}
