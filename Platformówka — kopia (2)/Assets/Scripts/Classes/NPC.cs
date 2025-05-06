using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public GameObject shopCanvas;
    public Player player;
    public float minDistance;

    // Start is called before the first frame update
    void Start()
    {
        minDistance = 2;
        showNickname();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerNear();
    }

    void CheckPlayerNear()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < minDistance)
        {
            shopCanvas.gameObject.SetActive(true);
        }
        else
        {
            shopCanvas.gameObject.SetActive(false);
        }
    }

    override public void showNickname()
    {
        nickname.text = "NPC";
        nickname.color = Color.yellow;
    }
}
