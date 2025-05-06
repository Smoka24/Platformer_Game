using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButtonClicked()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void exitButtonClicked()
    {
        Application.Quit();
    }

    public void statisticsButtonClicked()
    {
        SceneManager.LoadScene("Statistics");
    }

    public void loadButtonClicked()
    {
        SceneManager.LoadScene("Load");
    }
}
