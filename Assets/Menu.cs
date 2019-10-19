using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        //SceneManager.LoadScene("Level2");
    }

    public void ShowCommands()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
