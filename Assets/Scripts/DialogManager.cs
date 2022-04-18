using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public GameObject[] dialog;
    public GameObject lily;
    public GameObject tedrose;

    private int dialogIndex;
    private Scene currentScene;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();

        currentScene = SceneManager.GetActiveScene();
        lily.SetActive(false);
        tedrose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dialog.Length; i++)
        {
            if (i == dialogIndex)
            {
                dialog[i].SetActive(true);
            }
            else
            {
                dialog[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            dialogIndex++;
            if (dialogIndex == 3)
            {
                lily.SetActive(true);
                tedrose.SetActive(true);
            }

            if (dialogIndex == dialog.Length)
            {
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            }
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene(2);
    }
}
