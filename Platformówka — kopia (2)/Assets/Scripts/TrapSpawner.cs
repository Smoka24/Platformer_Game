using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject randomObject;

    public int difficulty;
    public float delay;
    public float[] spawnpoints;
    float timeFromSpawn;
    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        timeFromSpawn = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeFromSpawn >= delay)
        {
            int temp1 = rand.Next(0, 10);
            if (temp1 <= difficulty)
            {
                Instantiate(randomObject, new Vector2(transform.position.x, spawnpoints[rand.Next(0, spawnpoints.Length)]), transform.rotation);
                timeFromSpawn = 0;
            }

        }
        timeFromSpawn += Time.deltaTime;
    }
}
