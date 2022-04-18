using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI levelEndText;
    public TextMeshProUGUI finalScoreText;
    public Button nextLevel;
    public int winConditions; //number of good pics required to win the level
    public bool outOfPics = false;

    private PointsSystem thePointSys;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        thePointSys = FindObjectOfType<PointsSystem>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (outOfPics)
        {
            if(thePointSys.score >= winConditions)
            {
                levelEndText.text = "You won! :)";
            }

            else
            {
                levelEndText.text = "You lost... :(";
                nextLevel.interactable = false;
            }

            gameOverPanel.SetActive(true);
            finalScoreText.text = ((int)thePointSys.score).ToString();
            Time.timeScale = 0f;

            thePointSys.inFrameText.enabled = false;
            thePointSys.goodText.enabled = false;
            thePointSys.perfectText.enabled = false;
        }
    }

    public void PlayAgain()
    {
        outOfPics = false;
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextLevel()
    {
        outOfPics = false;
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    //for now it takes you back to the start screen, in actual game it'll take you back to menu selection
    public void Back()
    {
        outOfPics = false;
        SceneManager.LoadScene(0);
    }
}
