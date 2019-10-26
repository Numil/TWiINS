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
        if(player != null)
        {
            if (Input.GetKeyDown(player.gameObject.GetComponent<Mouvement>().activate) && isTriggered)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
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
