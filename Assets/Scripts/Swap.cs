﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap : MonoBehaviour
{
    public KeyCode swapPlaces;
    public KeyCode swapCharacter;

    private GameObject player1;
    private GameObject player2;
    private Mouvement mouvScriptP1;
    private Mouvement mouvScriptP2;
    private Text shownText = null;
    public Text text;
    public Canvas canvas;
    public bool isLittle;

    // On récupère les deux personnages
    void Awake()
    {
        player1 = GameObject.Find("Player One");
        player2 = GameObject.Find("Player Two");
        mouvScriptP1 = player1.GetComponent<Mouvement>();
        mouvScriptP2 = player2.GetComponent<Mouvement>();
    }

    void Update()
    {
      
        
        GameObject playerToCheck;


        if (player1.GetComponent<Swap>().isLittle)
        {
            playerToCheck = player1;
        }
        else
        {
            playerToCheck = player2;
        }

        //Permet de ne pas swap si le joueur est dans une mauvaise position 
        //Debug.DrawRay(playerToCheck.transform.position, playerToCheck.transform.up, Color.yellow);
        RaycastHit2D hit = Physics2D.Raycast(playerToCheck.transform.position, playerToCheck.transform.up, 0.52f);
        if (hit.collider == null)
        {
            if (Input.GetKeyDown(swapPlaces))
            {
                Vector3 player1Position = new Vector3(player1.transform.position.x, player1.transform.position.y);
                Vector3 player2Position = new Vector3(player2.transform.position.x, player2.transform.position.y);

                player1.transform.position = player2Position;
                player2.transform.position = player1Position;
            }
        }
        else
        {
            if (Input.GetKeyDown(swapPlaces))
            {
                if (shownText == null)
                {
                    shownText = Instantiate(text, new Vector3(playerToCheck.transform.position.x, playerToCheck.transform.position.y + 1f, playerToCheck.transform.position.z), new Quaternion(), canvas.transform);
                    StartCoroutine(DisableText());
                }
            }
        }

        // On échange les touches pour les deux personnages
       
        #region Contrôles swap
        if (Input.GetKeyDown(swapCharacter))
        {
            KeyCode p1Left = mouvScriptP1.left;
            KeyCode p1Right = mouvScriptP1.right;
            KeyCode p1Jump = mouvScriptP1.jump;
            KeyCode p1Action = mouvScriptP1.activate;
            KeyCode p1up = mouvScriptP1.up;
            string p1Name = mouvScriptP1.pName;

            KeyCode p2Left = mouvScriptP2.left;
            KeyCode p2Right = mouvScriptP2.right;
            KeyCode p2Jump = mouvScriptP2.jump;
            KeyCode p2Action = mouvScriptP2.activate;
            KeyCode p2up = mouvScriptP2.up;
            string p2Name = mouvScriptP2.pName;

            mouvScriptP1.left = p2Left;
            mouvScriptP1.right = p2Right;
            mouvScriptP1.jump = p2Jump;
            mouvScriptP1.activate = p2Action;
            mouvScriptP1.up = p2up;
            mouvScriptP1.pName = p2Name;

            mouvScriptP2.left = p1Left;
            mouvScriptP2.right = p1Right;
            mouvScriptP2.jump = p1Jump;
            mouvScriptP2.activate = p1Action;
            mouvScriptP2.up = p1up;
            mouvScriptP2.pName = p1Name;
        }
        #endregion
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(1f);
        Destroy(shownText.gameObject);
    }
}
