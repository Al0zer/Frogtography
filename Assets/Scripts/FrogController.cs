using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float speed = 2f;

    //determining positive (right) or negative (left) movement of frogs
    public int direction = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction * (speed * Time.deltaTime), 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndPoint")
        {
            Destroy(this.gameObject);
        }

        if(collision.tag == "InFrame")
        {
            FindObjectOfType<PointsSystem>().AddAverage();
        }

        if (collision.tag == "GoodShot")
        {
            FindObjectOfType<PointsSystem>().AddGood();
        }

        if (collision.tag == "PerfectShot")
        {
            FindObjectOfType<PointsSystem>().AddPerfect();
        }
    }
}
