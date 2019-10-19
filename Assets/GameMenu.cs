using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
