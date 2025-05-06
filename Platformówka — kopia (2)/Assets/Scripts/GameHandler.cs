using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using System.Text.RegularExpressions;

public class GameHandler : MonoBehaviour
{
    public SaveData saveData;

    public static bool gameOver;
    public GameObject GameMenu;
    public Text menuText;

    public Player player;
    public Text coins;
    public Text shopCoins;

    public string stringToSave;
    public string stringOfStats;

    public InputField inputField;
    public TextMeshPro nickname;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        GameMenu.gameObject.SetActive(false);
        stringOfStats = "0 | 0";
        stringToSave = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0)
        {
            gameOver = true;
        }   
        if (gameOver)
        {
            GameMenu.gameObject.SetActive(true);
            menuText.text = "Game Over";
        } 
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GameMenu.gameObject.SetActive(true);
        }
        shopCoins.text = coins.text;

        ChangeNickname();
    }
    public void ContinueButtonClick() 
    {
        if(gameOver)
        {
            string actualScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(actualScene);
            gameOver = false;
        }
        else
        {
            Time.timeScale = 1;
            GameMenu.gameObject.SetActive(false);
        }
    }

    public void ExitButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveStatistics(int valueChanged)
    {
        if(File.Exists("stats"))
        {
            stringOfStats = File.ReadAllText("stats");
        }
        else
        {
            File.Create("stats");
            File.WriteAllText("stats", "0 | 0");
        }
        string[] splitString = stringOfStats.Split('|');

        switch (valueChanged)
        {
            case 0:
                splitString[0] = (int.Parse(splitString[0]) + 1).ToString();
                break;
            case 1:
                splitString[1] = (int.Parse(splitString[1]) + 1).ToString();
                break;
        }
        stringOfStats = splitString[0] + " | " + splitString[1];
        File.WriteAllText("stats", stringOfStats);
    }

    public void ChangeNickname()
    {
        Regex regex = new Regex(@"^[a-zA-Z0-9]*$");

        if(regex.IsMatch(inputField.text) && inputField.text.Length <= 10)
        {
            nickname.text = inputField.text;
        }
        else
        {
            inputField.text = "";
        }

    }
}
