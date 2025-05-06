using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Object
{
    public Player player;
    public float originalPlayerSpeed = 5f;
    public int originalPlayerDamage = 10;

    public int damage;
    public float damageFrequencyTime = 1f;
    public float slowDuration = 15f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        slowDuration -= Time.deltaTime;
        if(slowDuration <= 0)
        {
            player.speed = originalPlayerSpeed;
            player.damage = originalPlayerDamage;
            slowDuration = 5f;

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "SlowTrap")
            {
                triggerSlowTrap();
            }
            else if(gameObject.tag == "SpikeTrap")
            {
                triggerSpikeTrap();
            }
            else if(gameObject.tag == "LavaTrap")
            {
                player.health = 0;
            }
        }
    }

    void triggerSlowTrap()
    {
        player.speed = player.speed / 2;
    }

    void triggerSpikeTrap()
    {
        if(player.health > damage)
        {
            player.health = player.health - damage;
        }
        else
        {
            player.health = 0;
        }

    }

}
