using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Fire : Ammunition
{
    public GameObject bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        notDestroyableTime -= Time.deltaTime;

        Transform spawnTransform = GameObject.Find("AmmoSpawn").transform;
        transform.position = spawnTransform.position;

        if (!Input.GetKey(KeyCode.P))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}
