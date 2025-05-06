using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : Ammunition
{
    GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        notDestroyableTime -= Time.deltaTime;

      moveBullet();
     
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(notDestroyableTime < 0 && collision.gameObject.tag != "bullet")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (notDestroyableTime < 0 && collision.gameObject.tag != "bullet")
        {
            Destroy(gameObject);
        }
    }
}
