using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLevelManager : MonoBehaviour
{
    public GameObject preLevelPanel;

    // Start is called before the first frame update
    void Start()
    {
       /* try
        {

        }*/
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
        Time.timeScale = 0f;
    }

    public void StartLevel()
    {
        preLevelPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Back()
    {
        SceneManager.LoadScene(3);
    }
}
