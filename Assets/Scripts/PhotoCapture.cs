using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoCapture : MonoBehaviour
{
    public int totalPics = 10;
    private int picsLeft;
    public TextMeshProUGUI picsLeftText;
    private GameOver gameOver;

    public Image photoDisplay;
    public GameObject photoFrame;
    public GameObject cameraFrame;

    public Animator fadingAnimation;

    private Texture2D screenCapture;
    private bool viewingPhoto;

    public int displayDuration = 1;

    public Collider2D inFrameTrigger;
    public Collider2D goodTrigger;
    public Collider2D perfectTrigger;

    private PointsSystem pointSystem;

    // Start is called before the first frame update
    void Start()
    {
        picsLeft = totalPics;

        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        inFrameTrigger.enabled = false;
        goodTrigger.enabled = false;
        perfectTrigger.enabled = false;

        gameOver = FindObjectOfType<GameOver>();

        pointSystem = FindObjectOfType<PointsSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        picsLeftText.text = "Pics Left: " + ((int)picsLeft).ToString() + "/" + totalPics;

        if (picsLeft != 0)
        {
            if (Input.GetKey("left shift") && (!viewingPhoto))
            {
                cameraFrame.SetActive(true);

                if (Input.GetKeyDown("space"))
                {
                    StartCoroutine(CapturePhoto());
                    StartCoroutine(DisableScoreTriggers());
                }
            }

            else
            {
                cameraFrame.SetActive(false);
            }
        }

        else
        {
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator CapturePhoto()
    {
        picsLeft -= 1;

        //triggers are only enabled while a photo is being taken 
        //allows to determine quality of photo immediately when it happens
        inFrameTrigger.enabled = true;
        goodTrigger.enabled = true;
        perfectTrigger.enabled = true;

        //disable all UI elements temporarily so they do not appear in the shot
        cameraFrame.SetActive(false);
        viewingPhoto = true;

        pointSystem.scoreText.enabled = false;
        picsLeftText.enabled = false;

        yield return new WaitForEndOfFrame();

        Rect regionToCapture = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToCapture, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

    // Disables colliders only after a full fixed cycle can occur
    // made by michael on january 21st 2023 at the alley on bayview we got the funny chainsaw man drinks hehe :)
    IEnumerator DisableScoreTriggers()
    {
        yield return new WaitForFixedUpdate();
        inFrameTrigger.enabled = false;
        goodTrigger.enabled = false;
        perfectTrigger.enabled = false;
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0f, 0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100f);
        photoDisplay.sprite = photoSprite;

        photoFrame.SetActive(true);

        fadingAnimation.Play("PhotoFade");

        StartCoroutine(RemovePhoto(displayDuration, photoFrame));
    }

    //displays the image for seconds before removing it, and enables the UI elements again
    IEnumerator RemovePhoto(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);

        viewingPhoto = false;
        obj.SetActive(false);

        pointSystem.scoreText.enabled = true;
        picsLeftText.enabled = true;

    }

    //using a coroutine here so that when the last picture is taken, 
    //it gives some time to actually display it before ending the level
    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1);

        photoFrame.SetActive(false);
        picsLeftText.enabled = false;
        pointSystem.scoreText.enabled = false;

        gameOver.outOfPics = true;
    }
}
