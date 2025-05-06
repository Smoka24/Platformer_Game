using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    public int gold;
    public string weaponEquipped;
    public float reloadSpeed;
    public TextMeshPro nickname;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void showNickname()
    {
        nickname.text = "Character";
        nickname.color = Color.white;
    }
}
