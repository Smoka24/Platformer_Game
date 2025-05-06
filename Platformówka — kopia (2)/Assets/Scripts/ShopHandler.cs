using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public Player player;
    public GameObject shopCanvas;
    
    public Button bulletButton;
    public Button manyBulletsButton;
    public Button shortFireButton;
    public Button fireButton;

    public int priceManyBullets;
    public int priceShortFire;
    public int priceFire;


    // Start is called before the first frame update
    void Start()
    {
        priceManyBullets = 5;
        priceShortFire = 7;
        priceFire = 10;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfCanBuy();
    }

    void checkIfCanBuy()
    {

        if(player.manyBulletsBought == false)
        {
            if (player.gold < priceManyBullets)
            {
                manyBulletsButton.interactable = false;
            }
            else
            {
                manyBulletsButton.interactable = true;
            }
        }
        else
        {
            manyBulletsButton.interactable = true;
        }

        if(player.shortFireBought == false)
        {
            if (player.gold < priceShortFire)
            {
                shortFireButton.interactable = false;
            }
            else
            {
                shortFireButton.interactable = true;
            }
        }
        else
        {
            shortFireButton.interactable = true;
        }

        if(player.FireBought == false)
        {
            if (player.gold < priceFire)
            {
                fireButton.interactable = false;
            }
            else
            {
                fireButton.interactable = true;
            }
        }
        else
        {
            fireButton.interactable = true;
        }

    }

    public void BulletButtonClick()
    {
        player.weaponEquipped = "bullet";
    }
    public void ManyBulletsButtonClick()
    {
        if(player.manyBulletsBought == false)
        {
            player.gold -= priceManyBullets;
            player.manyBulletsBought = true;
           
        }
        player.weaponEquipped = "manybullets";

    }
    public void ShortFireButtonClick()
    {
        if(player.shortFireBought == false)
        {
            player.gold -= priceShortFire;
            player.shortFireBought = true;
        }
        player.weaponEquipped = "shortFire";
    }
    public void FireButtonClick()
    {
        if(player.FireBought == false)
        {
            player.gold -= priceFire;
            player.FireBought = true;
        }
        player.weaponEquipped = "fire";
    }
}
