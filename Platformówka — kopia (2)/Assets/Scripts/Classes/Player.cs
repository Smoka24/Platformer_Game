using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public Text healthText;
    public Text coinsText;

    public bool manyBulletsBought;
    public bool shortFireBought;
    public bool FireBought;

    // Start is called before the first frame update
    void Start()
    {
        showNickname();
        manyBulletsBought = false;
        shortFireBought = false;
        FireBought = false;
        health = 100;
        speed = 5f;
        weaponEquipped = "bullet";
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        coinsText.text = gold.ToString();
    }

    override public void showNickname()
    {
        nickname.color = Color.green;
    }
}
