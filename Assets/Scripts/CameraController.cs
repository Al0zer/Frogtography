using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panMaxX;
    public float panMinX;
    public float panMaxY;
    public float panMinY;

    public float zoomMaxX;
    public float zoomMinX;
    public float zoomMaxY;
    public float zoomMinY;

    public float minCrop;
    public float maxCrop;

    public float speed = 10f;
    public float zoom = 2.5f;

    public bool zoomed = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        //CAMERA PANNING (USING WASD)
        //pan up
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        //pan down
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        //pan right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        //pan left
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        //if space bar is held down, zoom in 
        if (Input.GetKeyDown("left shift"))
        {
            zoomed = true;

            Camera.main.orthographicSize = zoom;
        }

        //when space bar is released, reset zoom 
        if (Input.GetKeyUp("left shift"))
        {
            zoomed = false;

            Camera.main.orthographicSize = 5.0f;
        }

        if (zoomed)
        {
            pos.x = Mathf.Clamp(pos.x, zoomMinX, zoomMaxX);
            pos.y = Mathf.Clamp(pos.y, zoomMinY, zoomMaxY);
        }

        else
        {
            pos.x = Mathf.Clamp(pos.x, panMinX, panMaxX);
            pos.y = Mathf.Clamp(pos.y, panMinY, panMaxY);
        }

        transform.position = pos;

    }
}
