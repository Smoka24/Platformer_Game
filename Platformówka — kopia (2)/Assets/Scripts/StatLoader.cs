using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatLoader : MonoBehaviour
{
    public Text coins;
    public Text hearts;
    public string loadedStats;

    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists("stats"))
        {
            loadedStats = File.ReadAllText("stats");
        }
        else
        {
            Debug.Log("File not found");
            return;
        }
        string[] splitString = loadedStats.Split('|');
        coins.text = splitString[0];
        hearts.text = splitString[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
