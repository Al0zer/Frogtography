using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    public float X;
    public float maxY;
    public float minY;

    public float timeBetweenSpawn;
    private float spawnTime;
    private int rand;

    public GameObject[] sprites;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomY = Random.Range(minY, maxY);

        rand = Random.Range(0, sprites.Length);

        Instantiate(sprites[rand], transform.position + new Vector3(X, randomY, 0), transform.rotation);
    }
}
