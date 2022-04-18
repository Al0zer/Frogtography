using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI[] hint;
    private int hintIndex;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hint.Length; i++)
        {
            if (i == hintIndex)
            {
                hint[i].enabled = true;
            }
            else
            {
                hint[i].enabled = false;
            }
        }

        if (hintIndex == 0)
        {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                hintIndex++;
            }
        }

        else if (hintIndex == 1)
        {
            if (Input.GetKey("left shift"))
            {
                hintIndex++;
            }
        }

        else if (hintIndex == 2)
        {
            if (Input.GetKey("left shift") && Input.GetKeyDown("space"))
            {
                hint[2].enabled = false;
                GameObject.Find("SkipTutorialButton").SetActive(false);
                hintIndex++;
            }
        }

        else
        {
            StartCoroutine(EndTutorial());
        }
    }

    IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }

    public void Skip()
    {
        SceneManager.LoadScene(4);
    }
}
