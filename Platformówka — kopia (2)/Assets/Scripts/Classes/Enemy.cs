using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Player player;
    public float damageFrequencyTime = 1f;
    public Gold goldToSpawn = new Gold();

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        showNickname();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dealDamage();
        }
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "fire")
        {
            health -= player.damage;
            if (health <= 0)
            {
                Instantiate(goldToSpawn, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            damageFrequencyTime -= Time.deltaTime;
            if (damageFrequencyTime <= 0)
            {
                dealDamage();
                damageFrequencyTime = 1f;
            }

        }

        if (collision.gameObject.tag == "fire")
        {
            damageFrequencyTime -= Time.deltaTime;
            if (damageFrequencyTime <= 0)
            {
                health -= player.damage;
                damageFrequencyTime = 1f;
                if (health <= 0)
                {
                    Instantiate(goldToSpawn, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }

    }

    void dealDamage()
    {
        player.health -= damage;
    }

    public override void showNickname()
    {
        nickname.text = "Enemy";
        nickname.color = Color.red;
    }
}
