using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public KeyCode swapPlaces;
    public KeyCode swapCharacter;

    private GameObject player1;
    private GameObject player2;
    private Mouvement mouvScriptP1;
    private Mouvement mouvScriptP2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player One");
        player2 = GameObject.Find("Player Two");
        mouvScriptP1 = player1.GetComponent<Mouvement>();
        mouvScriptP2 = player2.GetComponent<Mouvement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(swapPlaces))
        {
            Vector3 player1Position = new Vector3(player1.transform.position.x, player1.transform.position.y);
            Vector3 player2Position = new Vector3(player2.transform.position.x, player2.transform.position.y);

            player1.transform.position = player2Position;
            player2.transform.position = player1Position;
        }

        if (Input.GetKeyDown(swapCharacter))
        {
            KeyCode p1Left = mouvScriptP1.left;
            KeyCode p1Right = mouvScriptP1.right;
            KeyCode p1Jump = mouvScriptP1.jump;
            string p1Name = mouvScriptP1.pName;

            KeyCode p2Left = mouvScriptP2.left;
            KeyCode p2Right = mouvScriptP2.right;
            KeyCode p2Jump = mouvScriptP2.jump;
            string p2Name = mouvScriptP2.pName;

            mouvScriptP1.left = p2Left;
            mouvScriptP1.right = p2Right;
            mouvScriptP1.jump = p2Jump;
            mouvScriptP1.pName = p2Name;

            mouvScriptP2.left = p1Left;
            mouvScriptP2.right = p1Right;
            mouvScriptP2.jump = p1Jump;
            mouvScriptP2.pName = p1Name;
        }
    }
}
