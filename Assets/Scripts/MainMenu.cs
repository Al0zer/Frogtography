using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void AllLevels()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
