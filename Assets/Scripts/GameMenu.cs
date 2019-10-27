using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;

    // Activés par les boutons du menu
    public void ShowGameMenu()
    {
        if (gameMenu.activeSelf)
        {
            gameMenu.SetActive(false);
        }
        else
        {
            gameMenu.SetActive(true);
        }      
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
