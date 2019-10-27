using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    bool isTriggered;
    Collider2D player;


    private void Update()
    {
        // Si un joueur est dans la zone et appuie sur la touche d'action on termine le niveau
        if(player != null)
        {
            if (Input.GetKeyDown(player.gameObject.GetComponent<Mouvement>().activate) && isTriggered)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }


    // Permet de checker si le personnage entre dans le trigger de fin
    private void OnTriggerStay2D(Collider2D collision)
    {
        player = collision;
        isTriggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
}
