using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : Object
{
    public GameHandler gameHandler;

    public Player player;
    public Text coinText;
    public Text healthText;

    public float slowDuration = 5f;
    public float originalPlayerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slowDuration -= Time.deltaTime;
        if (slowDuration <= 0)
        {
            player.speed = originalPlayerSpeed;
            slowDuration = 5f;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectiblePickedUp();
        }
    }
    

    void collectiblePickedUp()
    {

        // Add the collectible to the player's inventory      
        // Destroy the collectible
        if (gameObject.tag == "coin")
        {
            player.gold += 1;
            updateCoinValue();
        }
        else if (gameObject.tag == "heart")
        {
            player.health += 10;
            updateHealthValue();
        }
        else if (gameObject.tag == "pickUpSlow")
        {
            player.speed = player.speed / 2;
        }
        else if (gameObject.tag == "pickUpSpeed")
        {
            player.speed = player.speed * 2;
        }
        else if (gameObject.tag == "pickUpDamage")
        {
            player.damage = player.damage * 2;
        }
        Destroy(gameObject);
    }

    void updateCoinValue()
    {
        coinText.text = player.gold.ToString();
        gameHandler.SaveStatistics(0);
    }
    void updateHealthValue()
    {
        healthText.text = player.health.ToString();
    }
}
