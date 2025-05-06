using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    public float movementSpeed;
    float ReloadSpeed;

    public float jumpForce;
    public float liftingForce;

    public bool jumped;
    public bool doubleJumped;

    public Rigidbody2D rb;
    public float startingY;

    public Text points;
    private int numberOfPoints;

    public Player player;
    public Bullets bullet;
    public GameObject fire;
    public GameObject shortFire;

    public float bulletsOffset = 20;
    public GameObject bulletSpawnPoint;

    public float nicknameOffset = 1.5f;
    public TextMeshPro nickname;
    public GameObject textHolder;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startingY = transform.position.y + 0.03f;
        movementSpeed = player.speed;
        ReloadSpeed = player.reloadSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ReloadSpeed -= Time.deltaTime;

        //Movement on WASD
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * player.speed * Time.deltaTime;
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.down * player.speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * player.speed * Time.deltaTime;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Shooting on P key
        if (Input.GetKey(KeyCode.P))
        {
            if(player.weaponEquipped == "bullet")
            {
                if (ReloadSpeed <= 0)
                {
                    ReloadSpeed = player.reloadSpeed;
                    Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                }
            }
            else if(player.weaponEquipped == "manybullets")
            {
                if(ReloadSpeed <= 0)
                {
                    ReloadSpeed = player.reloadSpeed;
                    Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                    spawnManyBullets();
                }

            }
            else if (player.weaponEquipped == "fire")
            {
                if(GameObject.Find("Fire(Clone)") == null && ReloadSpeed <= 0)
                {
                    Instantiate(fire, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                }
                if (ReloadSpeed <= 0)
                {
                    ReloadSpeed = player.reloadSpeed;             
                }
            }
            else if (player.weaponEquipped == "shortFire")
            {
                if (GameObject.Find("shortFire(Clone)") == null && ReloadSpeed <= 0)
                {
                    Instantiate(shortFire, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                }
                if (ReloadSpeed <= 0)
                {
                    ReloadSpeed = player.reloadSpeed;
                }
            }


        }

        if (jumped && transform.position.y <= startingY)
        {
            jumped = false;
            doubleJumped = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!jumped)
            {
                rb.velocity = new Vector2(0f, jumpForce);
                jumped = true;
            }
            else if (!doubleJumped)
            {
                rb.velocity = new Vector2(0f, jumpForce);
                doubleJumped = true;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }

        calculateNicknamePosition();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            numberOfPoints++;
            Destroy(collision.gameObject);
           
        }

    }

    void spawnManyBullets()
    {         
        Vector2 spawnPosition = (Vector2)player.transform.position + Vector2.up * bulletsOffset;
        Instantiate(bullet, spawnPosition, player.transform.rotation);
        spawnPosition = (Vector2)player.transform.position + Vector2.down * bulletsOffset;
        Instantiate(bullet, spawnPosition, player.transform.rotation);
    }

    void calculateNicknamePosition()
    {
        Vector3 vector3 = new Vector3(player.transform.position.x, player.transform.position.y + nicknameOffset);

        if(player.transform.rotation.y == -180)
        {
            vector3 = new Vector3(player.transform.position.x, player.transform.position.y + nicknameOffset);
            
        }
        else if(player.transform.rotation.y == 0)
        {
            vector3 = new Vector3(player.transform.position.x, player.transform.position.y + nicknameOffset);
        }

        nickname.transform.position = vector3;
        nickname.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}


