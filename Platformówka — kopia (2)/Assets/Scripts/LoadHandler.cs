using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickedTestLevel()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void clickedLoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void clickedLoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void backButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
