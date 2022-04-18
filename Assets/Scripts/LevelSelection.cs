using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
    }

    public void Fall()
    {
        SceneManager.LoadScene(4);
    }

    public void Winter()
    {
        SceneManager.LoadScene(5);
    }

    public void Spring()
    {
        SceneManager.LoadScene(6);
    }
    
    public void Summer()
    {
        SceneManager.LoadScene(7);
    }

    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
