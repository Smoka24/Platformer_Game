using UnityEngine;
using System.Collections;

namespace
{
    public class TrapSpawner : MonoBehaviour
    {
        public GameObject randomObject;

        public int difficulty;
        public float delay;
        public float[] spawnpoints;
        float timeFromSpawn;
        System.Random rand = new System.Random();

        // Use this for initialization
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
                if(temp1<=difficulty)
                {
                    Instantiate(randomObject, new Vector2(transform.position.x, spawnpoints[rand.Next(0, spawnpoints.Length)]), transform.rotation);
                    timeFromSpawn = 0;
                }
               
            }
            timeFromSpawn += Time.deltaTime;
        }
    }
}