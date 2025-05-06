using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : Object
{
    public float bulletSpeed;
    public float notDestroyableTime;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected void moveBullet()
    {
        Rigidbody2D bulletRb = gameObject.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(gameObject.transform.right * bulletSpeed, ForceMode2D.Impulse);

        if (bulletRb.velocity.magnitude > bulletSpeed)
        {
            bulletRb.velocity = bulletRb.velocity.normalized * bulletSpeed;
        }
    }


}
