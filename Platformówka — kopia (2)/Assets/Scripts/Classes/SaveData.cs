using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using System.Threading;

public class SaveData : MonoBehaviour
{
    public Player player;
    public string stringToSave;
    public Thread savingThread;

    // Start is called before the first frame update
    void Start()
    {
        string level = SceneManager.GetActiveScene().name;
        Load(level);
    }

    // Update is called once per frame
    void Update()
    {
        stringToSave = player.gold.ToString() + "|" + player.health.ToString() + "|" + player.manyBulletsBought.ToString() + "|" + player.shortFireBought.ToString() + "|" + player.FireBought.ToString();
    }

    IEnumerator Save()
    {
        Debug.Log("Building proper save");
        string level = SceneManager.GetActiveScene().name;
        Debug.Log("Starting save");

        if (File.Exists(level) == false)
        {
            File.Create(level);
        }
        File.WriteAllText(level, stringToSave);
        Debug.Log("Game Saved");
        yield return null;
    }

    public void Load(string level)
    {
        if (File.Exists(level) == false)
        {
            Debug.Log("No save file found");
            return;
        }
        else
        {
            string loadedString = File.ReadAllText(level);
            string[] splitString = loadedString.Split('|');
            player.gold = int.Parse(splitString[0]);
            player.health = int.Parse(splitString[1]);
            player.manyBulletsBought = bool.Parse(splitString[2]);
            player.shortFireBought = bool.Parse(splitString[3]);
            player.FireBought = bool.Parse(splitString[4]);
        }

    }

    public void SaveButtonClicked()
    {
        Debug.Log("Save Button Clicked");
        StartCoroutine(Save());
    }

    public void LoadButtonClicked()
    {
        Debug.Log("Load Button Clicked");
        SceneManager.LoadScene("Load");
    }

}
